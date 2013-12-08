
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "BTC/EUR")]
    public class VircurexBTCEURAPI:VircurexAPI, ITickerApi
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
}

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "BTC/USD")]
    public class VircurexBTCUSDAPI:VircurexAPI, ITickerApi
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
}

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "ANC/BTC")]
    public class VircurexANCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("anc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("anc", "btc"));
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "DGC/BTC")]
    public class VircurexDGCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("dgc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("dgc", "btc"));
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "DVC/BTC")]
    public class VircurexDVCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("dvc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("dvc", "btc"));
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "FRC/BTC")]
    public class VircurexFRCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("frc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("frc", "btc"));
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "FTC/BTC")]
    public class VircurexFTCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ftc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ftc", "btc"));
        }
    }
}

