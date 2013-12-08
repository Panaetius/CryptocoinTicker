using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

using Newtonsoft.Json.Linq;

namespace CryptocoinTicker.BitstampPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Bitstamp")]
    [ExportMetadata("Pair", "BTC/USD")]
    public class BitstampAPI:ITickerApi
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

                    var assembly = Assembly.GetAssembly(typeof(BitstampAPI));
                    var directory = Path.GetDirectoryName(assembly.CodeBase);
                    var filename = Path.GetFileName(assembly.CodeBase);
                    var assemblyPath = Path.Combine(directory, filename);
                    config = ConfigurationManager.OpenExeConfiguration(new Uri(assemblyPath).LocalPath);
                }

                return config;
            }
        }

        public IEnumerable<Trade> GetTradesAsync()
        {
            var trades = new List<Trade>();

            string filename = "Bitstamp";

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

            if (lastTrade != null && DateTime.Now.Subtract(lastTrade.Date).TotalSeconds < 60)
            {
                result = this.WebServiceCall(CurrentConfiguration.AppSettings.Settings["TradesURL"].Value + "?time=minute");
            }
            else
            {
                result = this.WebServiceCall(CurrentConfiguration.AppSettings.Settings["TradesURL"].Value);
            }
            
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

        public Depth GetDepthAsync()
        {
            var result = this.WebServiceCall(CurrentConfiguration.AppSettings.Settings["DepthUrl"].Value);

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
                        }).Where(a => a.Price > 0),
                Bids =
                    bids.Select(
                        b =>
                        new DepthItem
                        {
                            Amount = b[1].Value<decimal>(),
                            Price = b[0].Value<decimal>()
                        }).Where(b => b.Price > 0)
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

        public Task<IEnumerable<Trade>> GetTrades()
        {
            return Task.Run(() => this.GetTradesAsync());
        }

        public Task<Depth> GetDepth()
        {
            return Task.Run(() => this.GetDepthAsync());
        }
    }
}
