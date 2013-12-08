using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

using CryptocoinTicker.Contract;

using Newtonsoft.Json.Linq;

namespace CryptocoinTicker.VircurexPlugins
{
    public class VircurexAPI
    {
        private static Configuration config;

        public static Configuration CurrentConfiguration
        {
            get
            {
                if (config == null)
                {
                    // Added the next bit
                    AppDomain.CurrentDomain.AssemblyResolve += (o, args) =>
                    {
                        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                        return loadedAssemblies.FirstOrDefault(asm => asm.FullName == args.Name);
                    };

                    var assembly = Assembly.GetAssembly(typeof(VircurexAPI));
                    var directory = Path.GetDirectoryName(assembly.CodeBase);
                    var filename = Path.GetFileName(assembly.CodeBase);
                    var assemblyPath = Path.Combine(directory, filename);
                    config = ConfigurationManager.OpenExeConfiguration(new Uri(assemblyPath).LocalPath);
                }

                return config;
            }
        }

        public IEnumerable<Trade> GetTrades(string fromCurrency, string toCurrency)
        {
            var querystring = string.Format("base={0}&alt={1}", fromCurrency, toCurrency);

            var result = this.WebServiceCall("trades", querystring);

            var trades = new List<Trade>();

            var tradeArray = (JArray)result["root"];

            foreach (var tradeEntry in tradeArray)
            {
                var trade = new Trade();

                trade.Amount = tradeEntry["amount"].Value<decimal>();
                trade.Price = tradeEntry["price"].Value<decimal>();
                trade.TransactionId = tradeEntry["tid"].Value<string>();
                trade.Date = UnixTimeStampToDateTime(tradeEntry["date"].Value<long>()).ToLocalTime();

                trades.Add(trade);
            }

            return trades;
        }

        public Depth GetDepth(string fromCurrency, string toCurrency)
        {
            var querystring = string.Format("base={0}&alt={1}", fromCurrency, toCurrency);


            var result = this.WebServiceCall("orderbook", querystring);

            var asks = result["root"]["asks"] as JArray;
            var bids = result["root"]["bids"] as JArray;

            return new Depth
                            {
                                Asks =
                                    asks.Select(
                                        a =>
                                        new DepthItem
                                            {
                                                Amount = a[1].Value<decimal>(),
                                                Price = a[0].Value<decimal>()
                                            }),
                                Bids =
                                    bids.Select(
                                        b =>
                                        new DepthItem
                                            {
                                                Amount = b[1].Value<decimal>(),
                                                Price = b[0].Value<decimal>()
                                            })
                            };
        }

        private JObject WebServiceCall(string command, string querystring)
        {
            var url = string.Format(CurrentConfiguration.AppSettings.Settings["TradeUrl"].Value, command, querystring);

            var jsonString = new WebClient().DownloadString(url);

            return JObject.Parse("{\"root\": " + jsonString + "}");
        }

        private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}

