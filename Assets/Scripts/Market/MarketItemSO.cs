using BGS.Apparence;
using UnityEngine;

namespace BGS.Market
{
    [CreateAssetMenu(fileName = "MarketItemData", menuName = "Items/New Market Data", order = 1)]
    public class MarketItemSO : ScriptableObject, IMarketItem
    {
        public IApparence Data => _itemData;
        public int Price => _price;

        [SerializeField] private ApparenceSO _itemData;
        [SerializeField] private int _price;
    }
}

