using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/EUR")]
    public class BTCeLtcEurAPI:BTCeAPI, ITickerApi
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
                return "EUR";
            }
        }

        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_eur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_eur"));
        }
    }
}