﻿using System.Collections.Generic;
using System.ComponentModel.Composition;

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

        public IEnumerable<Trade> GetTrades()
        {
            return this.GetTrades("ltc_eur");
        }

        public Depth GetDepth()
        {
            return this.GetDepth("ltc_eur");
        }
    }
}