
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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.VircurexPlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Vircurex")]
    [ExportMetadata("Pair", "I0C/BTC")]
    public class VircurexI0CBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("i0c", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("i0c", "btc"));
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
    [ExportMetadata("Pair", "IXC/BTC")]
    public class VircurexIXCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ixc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ixc", "btc"));
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
    [ExportMetadata("Pair", "LTC/BTC")]
    public class VircurexLTCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc", "btc"));
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
    [ExportMetadata("Pair", "NMC/BTC")]
    public class VircurexNMCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc", "btc"));
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
    [ExportMetadata("Pair", "NVC/BTC")]
    public class VircurexNVCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nvc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nvc", "btc"));
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
    [ExportMetadata("Pair", "PPC/BTC")]
    public class VircurexPPCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ppc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ppc", "btc"));
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
    [ExportMetadata("Pair", "TRC/BTC")]
    public class VircurexTRCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("trc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("trc", "btc"));
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
    [ExportMetadata("Pair", "WDC/BTC")]
    public class VircurexWDCBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("wdc", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("wdc", "btc"));
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
    [ExportMetadata("Pair", "XPM/BTC")]
    public class VircurexXPMBTCAPI:VircurexAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xpm", "btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xpm", "btc"));
        }
    }
}

