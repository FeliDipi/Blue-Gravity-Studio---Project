using BGS.Apparence;
using BGS.Save;
using UnityEngine;

namespace BGS.InventoryModule
{
    public class Inventory : MonoBehaviour
    {
        public InventoryData Data => _data;

        [Header("Dependencies")]
        [SerializeField] private InventoryUI _inventoryUI;
        [SerializeField] private ApparenceManager _playerApparence;

        private InventoryData _data = new InventoryData();

        private void Start()
        {
            LoadInventory();
            _inventoryUI.Setup(this);
        }

        private void OnEnable()
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            if (!SaveSystem.Instance) return;

            if (SaveSystem.Instance.ExistData(_data.GetType()))
            {
                _data = SaveSystem.Instance.LoadData<InventoryData>(_data.GetType());
            }
            else SaveInventory();

            UpdateSelection();
        }

        private void SaveInventory()
        {
            SaveSystem.Instance.SaveData(_data.GetType(), _data);
        }

        private void UpdateSelection()
        {
            foreach (IApparence selection in _data.ItemsSelected.Values)
            {
                _playerApparence?.UpdateApparence(selection.Key, selection.Frames);
            }
        }

        public bool IsEquiped(string id)
        {
            foreach(IApparence itemData in _data.ItemsSelected.Values)
            {
                if (itemData.Id == id) return true;
            }

            return false;
        }

        public void SetEquip(string id)
        {
            IApparence itemData = GetItem(id);

            if (!_data.ItemsSelected.ContainsKey(itemData.Key))
            {
                _data.ItemsSelected.Add(itemData.Key, itemData);
            }
            else
            {
                _data.ItemsSelected[itemData.Key] = itemData;
            }

            SaveInventory();
            UpdateSelection();
        }

        public IApparence GetItem(string id)
        {
            foreach (IApparence itemData in _data.Items)
            {
                if (itemData.Id == id) return itemData;
            }

            return null;
        }
    }
}