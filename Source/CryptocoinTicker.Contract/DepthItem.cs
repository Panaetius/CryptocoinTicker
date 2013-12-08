namespace CryptocoinTicker.Contract
{
    public class DepthItem
    {
        public decimal Price { get; set; } 

        public decimal Amount { get; set; }

        public override string ToString()
        {
            return string.Format("Price: {0} Amount: {1}", Price, Amount);
        }
    }
}