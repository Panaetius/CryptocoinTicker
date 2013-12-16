using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/RUR")]
    public class BTCeLtcRurAPI : BTCeAPI, ITickerApi
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
                return "RUR";
            }
        }

        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_rur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_rur"));
        }
    }
}