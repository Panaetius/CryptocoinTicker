using System.Collections.Generic;

namespace CryptocoinTicker.Contract
{
    public class Depth
    {
        public IEnumerable<DepthItem> Asks { get; set; }  

        public IEnumerable<DepthItem> Bids { get; set; } 
    }
}