using BGS.Apparence;
using UnityEngine;

namespace BGS.MarketModule
{
    [CreateAssetMenu(fileName = "MarketItemData", menuName = "Items/New MarketModule Data", order = 1)]
    public class MarketItemSO : ScriptableObject, IMarketItem
    {
        public IApparence Data => _itemData;
        public int Price => _price;

        [SerializeField] private ApparenceSO _itemData;
        [SerializeField] private int _price;
    }
}