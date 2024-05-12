using BGS.Apparence;

namespace BGS.Market
{
    public interface IMarketItem
    {
        int Price { get; }
        IApparence Data { get; }
    }
}

