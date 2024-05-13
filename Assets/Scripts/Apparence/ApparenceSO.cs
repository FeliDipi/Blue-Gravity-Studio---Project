using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    [CreateAssetMenu(fileName = "apparence", menuName = "Apparence/New Apparence", order = 1)]
    public class ApparenceSO : ScriptableObject, IApparence
    {
        public string Id => _id;
        public string Title => _title;
        public string Description => _description;
        public Sprite Icon => _icon;
        public ApparenceRarity Rarity => _rarity;
        public ApparenceType Key => _key;
        public List<Sprite> Frames => _frames;

        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ApparenceRarity _rarity = ApparenceRarity.NORMAL;
        [SerializeField] private ApparenceType _key = ApparenceType.CLOTHE;
        [SerializeField] private List<Sprite> _frames;

        private readonly string _id;

        private ApparenceSO()
        {
            _id = Guid.NewGuid().ToString();
        }
    }
}