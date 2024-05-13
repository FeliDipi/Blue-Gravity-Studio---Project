using BGS.Apparence;
using BGS.InventoryModule;
using System;

public class InventoryUI : Gallery<Inventory>
{
    protected override void UpdateCells()
    {
        for (int i = 0; i < _manager.Data.Items.Count; i++)
        {
            IApparence data = _manager.Data.Items[i];

            Cell cell = _cells[i];

            cell.SetItem(data.Id, data.Icon);
            cell.OnSelect += SelectCell;

            cell.SetUsed(_manager.IsEquiped(data.Id));
        }
    }

    protected override void UpdateDescription()
    {
        IApparence item = _manager.GetItem(_cellSelected.GetData());

        _title.text = item.Title;
        _rarity.text = Enum.GetName(item.Rarity.GetType(), item.Rarity);
        _description.text = item.Description;
    }

    public void Equip()
    {
        if (!_cellSelected) return;

        _manager.SetEquip(_cellSelected.GetData());

        UpdateCells();
    }
}