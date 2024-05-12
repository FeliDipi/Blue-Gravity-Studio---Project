using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    public class ApparenceManager : MonoBehaviour
    {
        public static ApparenceManager Instance;

        [SerializeField] private Transform _reference;
        private Dictionary<ApparenceType, IApparenceApplicator> _apparences = new Dictionary<ApparenceType, IApparenceApplicator>();

        private IApparenceBase _base;

        private void Awake()
        {
            _base = _reference.GetComponent<IApparenceBase>();

            GetCustomApparences();
        }

        private void GetCustomApparences()
        {
            foreach (IApparenceApplicator apparence in _reference.GetComponentsInChildren<IApparenceApplicator>())
            {
                _apparences.Add(apparence.Key, apparence);
            }
        }

        private void Update()
        {
            if (_base == null) return;

            int frame = _base.GetCurrentFrame();

            foreach (IApparenceApplicator apparence in _apparences.Values)
            {
                apparence.SetFrame(frame);
            }
        }

        public void UpdateApparence(ApparenceType key, List<Sprite> frames)
        {
            if (!_apparences.ContainsKey(key)) return;

            _apparences[key].SetFrames(frames);
        }
    }
}

