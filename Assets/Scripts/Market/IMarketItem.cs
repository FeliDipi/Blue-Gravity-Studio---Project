using BGS.Apparence;

namespace BGS.MarketModule
{
    public interface IMarketItem
    {
        int Price { get; }
        IApparence Data { get; }
    }
}