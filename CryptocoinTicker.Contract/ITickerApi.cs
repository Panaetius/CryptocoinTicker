using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptocoinTicker.Contract
{
    public interface ITickerApi
    {
        Task<IEnumerable<Trade>> GetTrades();

        Task<Depth> GetDepth();
    }
}
