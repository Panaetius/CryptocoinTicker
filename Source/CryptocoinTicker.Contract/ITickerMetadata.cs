namespace CryptocoinTicker.Contract
{
    public interface ITickerMetadata
    {
        string Exchange { get; }

        string Pair { get; }
    }
}