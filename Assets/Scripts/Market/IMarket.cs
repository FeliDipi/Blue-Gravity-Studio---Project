using System.Collections.Generic;

namespace BGS.Market
{
    public interface IMarket
    {
        List<IMarketItem> Items { get; }

        public bool Purchase(IMarketItem item);
    }
}

