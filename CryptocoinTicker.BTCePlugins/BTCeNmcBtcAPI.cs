﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "BTCe")]
    [ExportMetadata("Pair", "NMC/BTC")]
    public class BTCeNmcBtcAPI : BTCeAPI, ITickerApi
    {
        public string FromCurrency
        {
            get
            {
                return "NMC";
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
            return await Task.Run(() => this.GetTrades("nmc_btc"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("nmc_btc"));
        }
    }
}