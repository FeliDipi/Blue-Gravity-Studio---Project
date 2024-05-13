using BGS.Apparence;
using System;
using System.Collections.Generic;

namespace BGS.InventoryModule
{
    [Serializable]
    public class InventoryData : IInventory
    {
        public List<IApparence> Items => _items;
        public Dictionary<ApparenceType, IApparence> ItemsSelected => _itemsSelected;

        private List<IApparence> _items = new List<IApparence>();
        private Dictionary<ApparenceType, IApparence> _itemsSelected = new Dictionary<ApparenceType, IApparence>();
    }
}