using BGS.Apparence;
using BGS.InventoryModule;
using BGS.Save;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BGS.MarketModule
{
    public class Market : MonoBehaviour, IMarket
    {
        public List<IMarketItem> Items => _items.ToList<IMarketItem>();

        [SerializeField] private string _itemsPath;
        [SerializeField] private List<MarketItemSO> _items;
        [SerializeField] private MarketUI _marketUI;

        private List<string> _itemsSolds = new List<string>();

        private void Awake()
        {
            LoadItems();
            SetupUI();
        }

        private void LoadItems()
        {
            if (SaveSystem.Instance && SaveSystem.Instance.ExistData(this.GetType()))
            {
                _itemsSolds = SaveSystem.Instance.LoadData<List<string>>(this.GetType());
            }

            _items = Resources.LoadAll<MarketItemSO>(_itemsPath).ToList();
        }

        private void SetupUI()
        {
            _marketUI.Setup(this);
        }

        private void UpdateInventory(IApparence data)
        {
            InventoryData inventory = SaveSystem.Instance.LoadData<InventoryData>(typeof(InventoryData));
            inventory.Items.Add(data);

            if (!inventory.ItemsSelected.ContainsKey(data.Key))
            {
                inventory.ItemsSelected.Add(data.Key, data);
            }
            else
            {
                inventory.ItemsSelected[data.Key] = data;
            }

            SaveSystem.Instance.SaveData(typeof(InventoryData), inventory);
        }

        public bool Purchase(IMarketItem item)
        {
            if (!CoinManager.Instance || !CoinManager.Instance.DiscountCoins(item.Price)) return false;

            _itemsSolds.Add(item.Data.Id);
            SaveSystem.Instance.SaveData(this.GetType(), _itemsSolds);

            UpdateInventory(item.Data);

            return true;
        }

        public bool IsSold(string id)
        {
            return _itemsSolds.Contains(id);
        }
    }
}