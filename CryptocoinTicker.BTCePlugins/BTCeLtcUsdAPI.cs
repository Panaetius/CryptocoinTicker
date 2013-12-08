using System.Collections.Generic;
using System.ComponentModel.Composition;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/USD")]
    public class BTCeLtcUsdAPI:BTCeAPI, ITickerApi
    {
        public string FromCurrency
        {
            get
            {
                return "LTC";
            }
        }

        public string ToCurrency
        {
            get
            {
                return "USD";
            }
        }

        public IEnumerable<Trade> GetTrades()
        {
            return this.GetTrades("ltc_usd");
        }

        public Depth GetDepth()
        {
            return this.GetDepth("ltc_usd");
        }
    }
}