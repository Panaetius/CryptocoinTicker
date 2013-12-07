using System.Collections.Generic;

namespace CryptocoinTicker.Contract
{
    public interface ITickerApi
    {
        string FromCurrency { get; }

        string ToCurrency { get; }

        IEnumerable<Trade> GetTrades();

        Depth GetDepth();
    }
}
