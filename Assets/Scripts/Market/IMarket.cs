using System.Collections.Generic;

namespace BGS.MarketModule
{
    public interface IMarket
    {
        List<IMarketItem> Items { get; }

        public bool Purchase(string itemId);
    }
}