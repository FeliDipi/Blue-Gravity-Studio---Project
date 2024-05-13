using BGS.Apparence;
using BGS.Save;
using UnityEngine;

namespace BGS.InventoryModule
{
    public class Inventory : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private ApparenceManager _playerApparence;

        private InventoryData _inventory = new InventoryData();

        private void Start()
        {
            LoadInventory();
        }

        private void OnEnable()
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            if (!SaveSystem.Instance) return;

            if (SaveSystem.Instance.ExistData(_inventory.GetType()))
            {
                _inventory = SaveSystem.Instance.LoadData<InventoryData>(_inventory.GetType());
            }
            else
            {
                SaveSystem.Instance.SaveData(_inventory.GetType(), _inventory);
            }

            UpdateSelection();
        }

        private void UpdateSelection()
        {
            foreach (IApparence selection in _inventory.ItemsSelected.Values)
            {
                _playerApparence?.UpdateApparence(selection.Key, selection.Frames);
            }
        }
    }
}