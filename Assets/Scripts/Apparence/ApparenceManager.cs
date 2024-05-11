using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    public class ApparenceManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _base;
        private Dictionary<string, CustomApparence> _apparences = new Dictionary<string, CustomApparence>();

        private void Awake()
        {
            GetCustomApparences();
        }

        private void GetCustomApparences()
        {
            foreach (CustomApparence apparence in _base.GetComponentsInChildren<CustomApparence>())
            {
                _apparences.Add(apparence.Key, apparence);
            }
        }

        private void Update()
        {
            if (!_base) return;

            string frameName = _base.sprite.name;
            string frameIndex = frameName.Substring(frameName.LastIndexOf('_') + 1);

            int frame = int.Parse(frameIndex);

            foreach (CustomApparence apparence in _apparences.Values)
            {
                apparence.SetFrame(frame);
            }
        }

        public void UpdateApparence(string key, List<Sprite> frames)
        {
            if (!_apparences.ContainsKey(key)) return;

            _apparences[key].SetDecoration(frames);
        }
    }
}

