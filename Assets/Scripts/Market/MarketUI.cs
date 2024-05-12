using BGS.Apparence;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Market
{
    public class MarketUI : MonoBehaviour
    {
        [Header("Preview Properties")]
        [SerializeField] private ApparenceManager _previewApparence;

        [Header("Gallery Properties")]
        [SerializeField] private Transform _grid;
        [SerializeField] private Transform _descriptionContent;

        [Header("Info Properties")]
        [SerializeField] private TMPro.TextMeshProUGUI _title;
        [SerializeField] private TMPro.TextMeshProUGUI _rarity;
        [SerializeField] private TMPro.TextMeshProUGUI _description;
        [SerializeField] private TMPro.TextMeshProUGUI _price;
        [SerializeField] private TMPro.TextMeshProUGUI _coins;

        private List<MarketCell> _cells = new List<MarketCell>();
        private Market _market;

        MarketCell _cellSelected;

        public void Setup(Market market)
        {
            _market = market;

            GetCells();
            SetupCells();

            UpdateCoins();
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
                cell.OnSelect += SelectCell;
            }
        }

        private void UpdateCoins()
        {
            _coins.text = CoinManager.Instance ? CoinManager.Instance.Coins.ToString() : "0";
        }

        private void UpdateDescription()
        {
            IMarketItem item = _cellSelected.GetData();

            _title.text = item.Data.Title;
            _rarity.text = Enum.GetName(item.Data.Rarity.GetType(), item.Data.Rarity);
            _description.text = item.Data.Description;
            _price.text = $"Buy ${item.Price}";
        }

        private void UpdatePreview()
        {
            IMarketItem item = _cellSelected.GetData();

            _previewApparence.UpdateApparence(item.Data.Key, item.Data.Frames);
        }

        public void SelectCell(MarketCell cellSelected)
        {
            _cellSelected = cellSelected;

            UpdateDescription();
            UpdatePreview();
        }

        public void PurchaseItem()
        {
            if (_cellSelected == null) return;

            bool purchaseSuccess = _market.Purchase(_cellSelected.GetData());

            if (!purchaseSuccess) return;

            _cellSelected.SetSold();
            _cellSelected = null;

            UpdateCoins();
        }
    }
}

