using BGS.Apparence;
using System.Collections.Generic;

namespace BGS.InventoryModule
{
    public interface IInventory
    {
        public List<IApparence> Items { get; }
        public Dictionary<ApparenceType, IApparence> ItemsSelected { get; }
    }
}