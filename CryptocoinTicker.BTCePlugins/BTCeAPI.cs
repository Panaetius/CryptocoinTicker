using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

using CryptocoinTicker.Contract;

using Newtonsoft.Json.Linq;

namespace CryptocoinTicker.BTCePlugins
{
    public class BTCeAPI
    {
        private static Configuration config;

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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

                    var assembly = Assembly.GetAssembly(typeof(BTCeAPI));
                    var directory = Path.GetDirectoryName(assembly.CodeBase);
                    var filename = Path.GetFileName(assembly.CodeBase);
                    var assemblyPath = Path.Combine(directory, filename);
                    config = ConfigurationManager.OpenExeConfiguration(new Uri(assemblyPath).LocalPath);
                }

                return config;
            }
        }

        public IEnumerable<Trade> GetTrades(string currencyPair)
        {
            var url = string.Format(CurrentConfiguration.AppSettings.Settings["BTCeTradesUrl"].Value, currencyPair);

            var jsonString = this.SimpleWebRequest(url);

            var jsonArray = JArray.Parse(jsonString);

            var trades = new List<Trade>();

            string filename = string.Format("BTCe_{0}.txt", currencyPair);

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

            foreach (var trade in jsonArray)
            {
                var parsedTrade = new Trade
                {
                    Date =
                        UnixEpoch.AddSeconds(trade["date"].Value<long>()),
                    TransactionId = trade["tid"].Value<string>(),
                    Amount = trade["amount"].Value<decimal>(),
                    Price = trade["price"].Value<decimal>()
                };

                trades.Add(parsedTrade);
            }

            trades = trades.Distinct().OrderBy(t => t.Date).ToList();

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

        /// <summary>
        /// The get depth.
        /// </summary>
        /// <param name="currencyPair">
        /// The currency Pair.
        /// </param>
        /// <returns>
        /// The depth
        /// </returns>
        /// <remarks>
        /// price is amount of toCurrency for 1 fromCurrency
        /// </remarks>
        protected Depth GetDepth(string currencyPair)
        {
            var url = string.Format(
                CurrentConfiguration.AppSettings.Settings["BTCeDepthUrl"].Value, currencyPair);

            var jsonString = this.SimpleWebRequest(url);

            var jsonObject = JObject.Parse(jsonString);

            var jsonAsks = (JArray)jsonObject["asks"];
            var jsonBids = (JArray)jsonObject["bids"];

            var asks =
                jsonAsks.Select(
                    ask => new DepthItem { Price = ask[0].Value<decimal>(), Amount = ask[1].Value<decimal>() }).ToList();

            var bids = jsonBids.Select(bid => new DepthItem { Price = bid[0].Value<decimal>(), Amount = bid[1].Value<decimal>() }).ToList();

            return new Depth{Asks = asks, Bids = bids};
        }

        private string SimpleWebRequest(string url)
        {
            return new WebClient().DownloadString(url);
        }
    }
}
