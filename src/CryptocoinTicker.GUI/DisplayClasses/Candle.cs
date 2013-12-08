using System;

namespace CryptocoinTicker.GUI.DisplayClasses
{
    public class Candle
    {
        public DateTime Date { get; set; } 

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Date: {0} High: {1} Low: {2} Open: {3} Close: {4} Volume: {5}",
                Date,
                High,
                Low,
                Open,
                Close,
                Volume);
        }
    }
}