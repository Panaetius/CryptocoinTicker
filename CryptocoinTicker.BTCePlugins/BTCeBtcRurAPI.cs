using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "BTC/RUR")]
    public class BTCeBtcRurAPI:BTCeAPI, ITickerApi
    {
        public string FromCurrency
        {
            get
            {
                return "BTC";
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
            return await Task.Run(() => this.GetTrades("btc_rur"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("btc_rur"));
        }
    }
}