using BGS.Apparence;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;

        private List<IApparence> _inventory = new List<IApparence>();

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else Destroy(this);
        }

        public void AddItem(IApparence newItem)
        {
            _inventory.Add(newItem);
        }

        public void UseItem(IApparence selected)
        {

        }
    }
}

