using BGS.Apparence;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.MarketModule
{
    public class MarketUI : Gallery<Market>
    {
        [Header("Market UI Properties")]
        [SerializeField] private ApparenceManager _previewApparence;
        [SerializeField] private TMPro.TextMeshProUGUI _price;

        private IMarketItem _currentData;

        protected override void UpdateCells()
        {
            for (int i = 0; i < _manager.Items.Count; i++)
            {
                IMarketItem data = _manager.Items[i];

                Cell cell = _cells[i];

                cell.SetItem(data.Data.Id, data.Data.Icon);
                cell.OnSelect += SelectCell;

                cell.SetUsed(_manager.IsSold(data.Data.Id));
            }
        }

        protected override void UpdateDescription()
        {
            _title.text = _currentData.Data.Title;
            _rarity.text = Enum.GetName(_currentData.Data.Rarity.GetType(), _currentData.Data.Rarity);
            _description.text = _currentData.Data.Description;
            _price.text = $"Buy ${_currentData.Price}";
        }

        private void UpdatePreview()
        {
            _previewApparence.UpdateApparence(_currentData.Data.Key, _currentData.Data.Frames);
        }

        public override void SelectCell(Cell cellSelected)
        {
            _currentData = _manager.GetItem(cellSelected.GetData());
            UpdatePreview();
            
            base.SelectCell(cellSelected);
        }

        public void PurchaseItem()
        {
            if (_cellSelected == null) return;

            bool purchaseSuccess = _manager.Purchase(_cellSelected.GetData());

            if (!purchaseSuccess) return;

            _cellSelected.SetUsed(true);
            _cellSelected = null;
        }
    }
}