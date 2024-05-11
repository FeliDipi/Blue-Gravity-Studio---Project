using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BGS.Market
{
    public class Market : MonoBehaviour, IMarket
    {
        public List<IMarketItem> Items => _items.ToList<IMarketItem>();

        [SerializeField] private string _itemsPath;
        [SerializeField] private List<MarketItemSO> _items;
        [SerializeField] private MarketUI _marketUI;

        private void Awake()
        {
            LoadItems();
            SetupUI();
        }

        private void LoadItems()
        {
            _items = Resources.LoadAll<MarketItemSO>(_itemsPath).ToList();
        }

        private void SetupUI()
        {
            _marketUI.Setup(this);
        }

        public void Purchase(IMarketItem item)
        {
            Debug.Log("Item purchased");
        }
    }
}

