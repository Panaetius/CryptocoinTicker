using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
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
    }
}