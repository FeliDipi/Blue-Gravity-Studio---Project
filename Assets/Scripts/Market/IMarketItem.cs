using BGS.Item;

namespace BGS.Market
{
    public interface IMarketItem
    {
        IItem ItemData { get; set; }
        int Price { get; set; }
    }
}
