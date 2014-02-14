











using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

using CryptocoinTicker.BTCePlugins;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "BTC/EUR")]
    public class BTCeBtcEurAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc_eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc_eur"));
        }

        public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "btc", "eur");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "btc", "eur");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "BTC/RUR")]
    public class BTCeBtcRurAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc_rur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc_rur"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "btc", "rur");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "btc", "rur");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "BTC/USD")]
    public class BTCeBtcUsdAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("btc_usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc_usd"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "btc", "usd");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "btc", "usd");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "EUR/USD")]
    public class BTCeEurUsdAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("eur_usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("eur_usd"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "eur", "usd");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "eur", "usd");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "FTC/BTC")]
    public class BTCeFtcBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ftc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ftc_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ftc", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ftc", "btc");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/BTC")]
    public class BTCeLtcBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ltc", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ltc", "btc");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/EUR")]
    public class BTCeLtcEurAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_eur"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ltc", "eur");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ltc", "eur");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/RUR")]
    public class BTCeLtcRurAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_rur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_rur"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ltc", "rur");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ltc", "rur");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/USD")]
    public class BTCeLtcUsdAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_usd"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ltc", "usd");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ltc", "usd");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "NMC/BTC")]
    public class BTCeNmcBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "nmc", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "nmc", "btc");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "NMC/USD")]
    public class BTCeNmcUsdAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nmc_usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc_usd"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "nmc", "usd");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "nmc", "usd");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "NVC/BTC")]
    public class BTCeNvcBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nvc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nvc_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "nvc", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "nvc", "btc");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "NVC/USD")]
    public class BTCeNvcUsdAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("nvc_usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nvc_usd"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "nvc", "usd");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "nvc", "usd");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "PPC/BTC")]
    public class BTCePpcBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ppc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ppc_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ppc", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ppc", "btc");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "PPC/USD")]
    public class BTCePpcUsdAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ppc_usd"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ppc_usd"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "ppc", "usd");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "ppc", "usd");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "TRC/BTC")]
    public class BTCeTrcBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("trc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("trc_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "trc", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "trc", "btc");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "USD/RUR")]
    public class BTCeUsdRurAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("usd_rur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("usd_rur"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "usd", "rur");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "usd", "rur");
        }
    }

	[Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "XPM/BTC")]
    public class BTCeXpmBtcAPI : BTCeAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("xpm_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("xpm_btc"));
        }

		public override long Buy(decimal price, decimal amount)
        {
            return MakeOrder("buy", amount, price, "xpm", "btc");
        }

        public override long Sell(decimal price, decimal amount)
        {
            return MakeOrder("sell", amount, price, "xpm", "btc");
        }
    }

  }