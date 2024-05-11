using System.Collections.Generic;

namespace BGS.Market
{
    public interface IMarket
    {
        List<IMarketItem> Items { get; set; }

        public void Purchase(IMarketItem item);
    }
}

