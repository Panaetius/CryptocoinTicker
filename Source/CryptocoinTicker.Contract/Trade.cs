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

        public override string ToString()
        {
            return String.Format(
                "Date: {0} Price: {1} Amount: {2} Tid: {3} Type: {4}",
                Date,
                Price,
                Amount,
                TransactionId,
                Type);
        }
    }
}
