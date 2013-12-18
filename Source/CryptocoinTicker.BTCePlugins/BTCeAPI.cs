using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CryptocoinTicker.Contract;
using CryptocoinTicker.Helpers;
using Newtonsoft.Json.Linq;

namespace CryptocoinTicker.BTCePlugins
{
    public abstract class BTCeAPI
    {
        private static Configuration config;

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private long Nonce
        {
            get
            {
                return ++nonce;
            }
        }

        private long nonce;

        private List<long> _orderIDs = new List<long>();

        protected BTCeAPI()
        {
            nonce = Convert.ToInt64(DateTime.Now.Subtract(UnixEpoch).TotalSeconds);
        }

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
                        UnixEpoch.AddSeconds(trade["date"].Value<long>()).ToLocalTime(),
                    TransactionId = trade["tid"].Value<string>(),
                    Amount = trade["amount"].Value<decimal>(),
                    Price = trade["price"].Value<decimal>()
                };

                trades.Add(parsedTrade);
            }

            trades = trades.GroupBy(t => t.TransactionId).Select(g => g.First()).OrderBy(t => t.Date).ToList();

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

        protected long MakeOrder(string type, double amount, double unitPrice, string fromCurrency, string toCurrency)
        {
            var requestParams = new Dictionary<string, string>();

            requestParams.Add("method", "Trade");

            requestParams.Add(
                "pair",
                string.Format("{0}_{1}", fromCurrency.ToLower(), toCurrency.ToLower()));

            requestParams.Add("type", type.ToString().ToLower());

            requestParams.Add("rate", Math.Round(unitPrice, 8).ToString());

            requestParams.Add("amount", Math.Round(amount, 8).ToString());

            var result = this.QueryWebRequest(requestParams);

            return result["order_id"].Value<long>();
        }

        protected abstract void Buy(decimal price, decimal amount);

        protected abstract void Sell(decimal price, decimal amount);

        private string SimpleWebRequest(string url)
        {
            return new WebClient().DownloadString(url);
        }

        private JObject QueryWebRequest(Dictionary<string, string> args)
        {
            args.Add("nonce", this.Nonce.ToString());

            var postParams = BuildPostParameters(args);

            var request = WebRequest.Create(new Uri(CurrentConfiguration.AppSettings.Settings["BTCeQueryUrl"].Value)) as HttpWebRequest;
            if (request == null)
            {
                throw new Exception("Non HTTP WebRequest");
            }

            request.Method = "POST";
            request.Timeout = 15000;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postParams.Length;

            var hashMaker = new HMACSHA512(Encoding.ASCII.GetBytes(Settings.Default.ApiSecret.DecryptString().ToInsecureString()));

            request.Headers.Add("Key", Settings.Default.ApiKey.DecryptString().ToInsecureString());
            request.Headers.Add("Sign", ByteArrayToString(hashMaker.ComputeHash(postParams)).ToLower());

            var reqStream = request.GetRequestStream();
            reqStream.Write(postParams, 0, postParams.Length);
            reqStream.Close();

            var result = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

            var jresult = JObject.Parse(result);

            if (jresult["success"].Value<int>() != 1)
            {
                var message = jresult["error"].Value<string>();

                if (message == "no orders")
                {
                    return new JObject();
                }

                throw new Exception(message);
            }

            return jresult["return"] as JObject;
        }

        private static byte[] BuildPostParameters(Dictionary<string, string> args)
        {
            var s = new StringBuilder();

            foreach (var item in args)
            {
                s.AppendFormat("{0}={1}", item.Key, HttpUtility.UrlEncode(item.Value));
                s.Append("&");
            }

            if (s.Length > 0)
            {
                s.Remove(s.Length - 1, 1);
            }

            return Encoding.ASCII.GetBytes(s.ToString());
        }

        private string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", string.Empty);
        }
    }
}
