
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

using CryptocoinTicker.MtGoxPlugins;

namespace CryptocoinTicker.MtGoxPlugins
{
                                [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/USD")]
    public class MtGoxBTCUSDAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "usd"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/GBP")]
    public class MtGoxBTCGBPAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "gbp"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "gbp"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/EUR")]
    public class MtGoxBTCEURAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "eur"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/JPY")]
    public class MtGoxBTCJPYAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "jpy"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "jpy"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/AUD")]
    public class MtGoxBTCAUDAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "aud"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "aud"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/CAD")]
    public class MtGoxBTCCADAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "cad"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "cad"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/CHF")]
    public class MtGoxBTCCHFAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "chf"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "chf"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/CNY")]
    public class MtGoxBTCCNYAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "cny"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "cny"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/DKK")]
    public class MtGoxBTCDKKAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "dkk"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "dkk"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/HKD")]
    public class MtGoxBTCHKDAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "hkd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "hkd"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/PLN")]
    public class MtGoxBTCPLNAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "pln"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "pln"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/RUB")]
    public class MtGoxBTCRUBAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "rub"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "rub"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/SEK")]
    public class MtGoxBTCSEKAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "sek"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "sek"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/SGD")]
    public class MtGoxBTCSGDAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "sgd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "sgd"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/THB")]
    public class MtGoxBTCTHBAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "thb"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "thb"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/NOK")]
    public class MtGoxBTCNOKAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "nok"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "nok"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "MtGox")]
    [ExportMetadata("Pair", "BTC/CZK")]
    public class MtGoxBTCCZKAPI:MtGoxAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc", "czk"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc", "czk"));
        }
    }


  }