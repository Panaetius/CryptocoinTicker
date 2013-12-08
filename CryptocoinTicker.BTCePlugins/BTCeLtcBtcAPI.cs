using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "LTC/BTC")]
    public class BTCeLtcBtcAPI : BTCeAPI, ITickerApi
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
                return "BTC";
            }
        }

        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("ltc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("ltc_btc"));
        }
    }
}