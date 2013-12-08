
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

using CryptocoinTicker.KrakenPlugins;

namespace CryptocoinTicker.KrakenPlugins
{
                                [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "LTC/XRP")]
    public class KrakenLTCXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "LTC/EUR")]
    public class KrakenLTCEURAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc", "eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc", "eur"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "LTC/KRW")]
    public class KrakenLTCKRWAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc", "krw"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc", "krw"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "LTC/USD")]
    public class KrakenLTCUSDAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc", "usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc", "usd"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "NMC/XRP")]
    public class KrakenNMCXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "NMC/EUR")]
    public class KrakenNMCEURAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc", "eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc", "eur"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "NMC/KRW")]
    public class KrakenNMCKRWAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc", "krw"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc", "krw"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "NMC/USD")]
    public class KrakenNMCUSDAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc", "usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc", "usd"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/LTC")]
    public class KrakenXBTLTCAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "ltc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "ltc"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/NMC")]
    public class KrakenXBTNMCAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "nmc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "nmc"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/XRP")]
    public class KrakenXBTXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/XVN")]
    public class KrakenXBTXVNAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "xvn"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "xvn"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/EUR")]
    public class KrakenXBTEURAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "eur"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/KRW")]
    public class KrakenXBTKRWAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "krw"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "krw"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XBT/USD")]
    public class KrakenXBTUSDAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xbt", "usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xbt", "usd"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "XVN/XRP")]
    public class KrakenXVNXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xvn", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xvn", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "EUR/XRP")]
    public class KrakenEURXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("eur", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("eur", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "EUR/XVN")]
    public class KrakenEURXVNAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("eur", "xvn"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("eur", "xvn"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "KRW/XRP")]
    public class KrakenKRWXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("krw", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("krw", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "USD/XRP")]
    public class KrakenUSDXRPAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("usd", "xrp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("usd", "xrp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Kraken")]
    [ExportMetadata("Pair", "USD/XVN")]
    public class KrakenUSDXVNAPI:KrakenAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("usd", "xvn"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("usd", "xvn"));
        }
    }


  }