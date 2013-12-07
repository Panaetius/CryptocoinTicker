using System.Collections.Generic;

namespace CryptocoinTicker.GUI.DisplayClasses
{
    public class Exchange
    {
        public string Name { get; set; }

        public List<CurrencyPair> Pairs { get; set; }
    }
}