using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

using Newtonsoft.Json.Linq;

namespace CryptocoinTicker.KrakenPlugins
{
    public class KrakenAPI
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

                    var assembly = Assembly.GetAssembly(typeof(KrakenAPI));
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
            var querystring = string.Format("?pair={0}{1}", fromCurrency, toCurrency);
            
            var trades = new List<Trade>();

            string filename = string.Format("Kraken_{0}r.txt", fromCurrency + toCurrency);

            if (File.Exists(filename))
            {
                var lines = File.ReadAllLines(filename);

                trades = lines.Select(
                    l =>
                    {
                        var splits = l.Split(';');
                        return new Trade
                        {
                            Amount = decimal.Parse(splits[0]),
                            Date = DateTime.Parse(splits[1]),
                            Price = decimal.Parse(splits[2]),
                            TransactionId = splits[3],
                            Type = splits[4] == "Buy" ? TradeType.Buy : TradeType.Sell
                        };
                    }).ToList();
            }

            JObject result;

            var lastTrade = trades.OrderByDescending(t => t.Date).FirstOrDefault();

            if (lastTrade != null)
            {
                querystring += "&since=" + lastTrade.TransactionId;

                result = this.WebServiceCall(string.Format(CurrentConfiguration.AppSettings.Settings["TradesURL"].Value, querystring));
            }
            else
            {
                result = this.WebServiceCall(string.Format(CurrentConfiguration.AppSettings.Settings["TradesURL"].Value, querystring));
            }

            var tradeArray = (JArray)result["root"]["result"].First.First;

            var tid = result["root"]["result"]["last"].Value<string>();

            foreach (var tradeEntry in tradeArray)
            {
                var trade = new Trade();

                trade.Amount = tradeEntry[1].Value<decimal>();
                trade.Price = tradeEntry[0].Value<decimal>();
                trade.TransactionId = tid;
                trade.Date = UnixTimeStampToDateTime(Convert.ToInt64(tradeEntry[2].Value<double>())).ToLocalTime();

                trades.Add(trade);
            }

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            File.WriteAllLines(
                filename,
                trades.Select(
                    t => string.Format("{0};{1};{2};{3};{4}", t.Amount, t.Date, t.Price, t.TransactionId, t.Type)));

            return trades;
        }

        public Depth GetDepth(string fromCurrency, string toCurrency)
        {
            var querystring = string.Format("?pair={0}{1}", fromCurrency, toCurrency);


            var result = this.WebServiceCall(string.Format(CurrentConfiguration.AppSettings.Settings["DepthURL"].Value, querystring));

            var asks = result["root"]["result"].First.First["asks"] as JArray;
            var bids = result["root"]["result"].First.First["bids"] as JArray;

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

        private JObject WebServiceCall(string url)
        {
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
