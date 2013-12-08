using System;

namespace CryptocoinTicker.Contract
{
    public class Trade
    {
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public TradeType Type { get; set; }

        public string TransactionId { get; set; }
    }
}
