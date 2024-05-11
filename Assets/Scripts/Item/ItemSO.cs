using UnityEngine;

namespace BGS.Item
{
    [CreateAssetMenu(fileName = "itemData", menuName = "Items/New Data", order = 1)]
    public class ItemSO : ScriptableObject, IItem
    {
        public string Title => _title;
        public string Description => _description;
        public Sprite Icon => _icon;
        public ItemRarity ItemRarity => _rarity;

        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemRarity _rarity = ItemRarity.NORMAL;
    }
}

