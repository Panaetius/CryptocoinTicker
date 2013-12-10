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

namespace CryptocoinTicker.CryptsyPlugins
{
    public class CryptsyAPI
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

                    var assembly = Assembly.GetAssembly(typeof(CryptsyAPI));
                    var directory = Path.GetDirectoryName(assembly.CodeBase);
                    var filename = Path.GetFileName(assembly.CodeBase);
                    var assemblyPath = Path.Combine(directory, filename);
                    config = ConfigurationManager.OpenExeConfiguration(new Uri(assemblyPath).LocalPath);
                }

                return config;
            }
        }

        public IEnumerable<Trade> GetTrades(string id)
        {
            var trades = new List<Trade>();

            string filename = string.Format("Cryptsy_{0}r.txt", id);

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

            result = this.WebServiceCall(string.Format(CurrentConfiguration.AppSettings.Settings["TradesURL"].Value, id));


            var tradeArray = (JArray)result["root"]["return"]["markets"].First.First["recenttrades"];

            foreach (var tradeEntry in tradeArray)
            {
                var trade = new Trade();

                trade.Amount = tradeEntry["quantity"].Value<decimal>();
                trade.Price = tradeEntry["price"].Value<decimal>();
                trade.TransactionId = tradeEntry["id"].Value<string>();
                trade.Date = DateTime.Parse(tradeEntry["time"].Value<string>());

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

        public Depth GetDepth(string id)
        {
            var result = this.WebServiceCall(string.Format(CurrentConfiguration.AppSettings.Settings["DepthURL"].Value, id));

            var asks = result["root"]["return"].First.First["buyorders"] as JArray;
            var bids = result["root"]["return"].First.First["sellorders"] as JArray;

            return new Depth
            {
                Asks =
                    asks.Select(
                        a =>
                        new DepthItem
                        {
                            Amount = a["quantity"].Value<decimal>(),
                            Price = a["price"].Value<decimal>()
                        }),
                Bids =
                    bids.Select(
                        b =>
                        new DepthItem
                        {
                            Amount = b["quantity"].Value<decimal>(),
                            Price = b["price"].Value<decimal>()
                        })
            };
        }

        private JObject WebServiceCall(string url)
        {
            var jsonString = new WebClient().DownloadString(url);

            return JObject.Parse("{\"root\": " + jsonString + "}");
        }
    }
}
