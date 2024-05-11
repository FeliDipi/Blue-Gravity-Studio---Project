using BGS.Item;

namespace BGS.Market
{
    public interface IMarketItem
    {
        IItem ItemData { get; }
        int Price { get; }
    }
}

