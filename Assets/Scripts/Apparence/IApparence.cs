using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    public interface IApparence
    {
        public string Id { get; }
        string Title { get; }
        string Description { get; }
        Sprite Icon { get; }
        ApparenceRarity Rarity { get; }
        public ApparenceType Key { get; }
        public List<Sprite> Frames { get; }
    }

    public enum ApparenceType
    {
        CLOTHE,
        HAIR
    }

    public enum ApparenceRarity
    {
        NORMAL,
        RARE,
        EPIC
    }
}