using UnityEngine;

namespace BGS.Item
{
    public interface IItem
    {
        string Title { get; }
        string Description { get; }
        Sprite Icon { get; }
        ItemRarity ItemRarity { get; }
    }

    public enum ItemRarity
    {
        NORMAL,
        RARE,
        EPIC
    }
}

