using BGS.Item;
using UnityEngine;

namespace BGS.Market
{
    [CreateAssetMenu(fileName = "MarketItemData", menuName = "Items/New Market Data", order = 1)]
    public class MarketItemSO : ScriptableObject, IMarketItem
    {
        public IItem ItemData => _itemData;
        public int Price => _price;

        [SerializeField] private ItemSO _itemData;
        [SerializeField] private int _price;
    }
}

