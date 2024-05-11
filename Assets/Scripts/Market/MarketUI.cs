using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BGS.Market
{
    public class MarketUI : MonoBehaviour
    {
        [Header("Gallery Properties")]
        [SerializeField] private Transform _grid;

        [Header("Info Properties")]
        [SerializeField] private TMPro.TextMeshProUGUI _title;
        [SerializeField] private TMPro.TextMeshProUGUI _rarity;
        [SerializeField] private TMPro.TextMeshProUGUI _description;
        [SerializeField] private TMPro.TextMeshProUGUI _price;
        [SerializeField] private ButtonEvent _purchaseBtn;

        private List<MarketCell> _cells = new List<MarketCell>();
        private Market _market;

        IMarketItem _itemSelected;

        public void Setup(Market market)
        {
            _market = market;

            GetCells();
            SetupCells();

            _purchaseBtn.OnClick += PurchaseItem;
        }

        private void GetCells()
        {
            foreach (Transform cell in _grid)
            {
                MarketCell marketCell = cell.GetComponent<MarketCell>();
                _cells.Add(marketCell);
            }
        }

        private void SetupCells()
        {
            if (_market.Items.Count <= 0) return;

            for (int i = 0; i < _market.Items.Count; i++)
            {
                MarketCell cell = _cells[i];

                cell.SetItem(_market.Items[i]);
                cell.OnSelect += SelectItem;
            }
        }

        public void SelectItem(IMarketItem itemSelected)
        {
            _itemSelected = itemSelected;

            _title.text = _itemSelected.ItemData.Title;
            _description.text = _itemSelected.ItemData.Description;
            _price.text = $"Buy ${_itemSelected.Price}";
        }

        public void PurchaseItem()
        {
            if (_itemSelected == null) return;

            _market.Purchase(_itemSelected);
        }
    }
}

