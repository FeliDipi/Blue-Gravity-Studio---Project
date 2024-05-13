using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    public class CustomApparence : MonoBehaviour, IApparenceApplicator
    {
        public ApparenceType Key => _type;

        public List<Sprite> Frames => _currentFrames;

        [SerializeField] private SpriteRenderer _spr;
        [SerializeField] private ApparenceType _type;

        private List<Sprite> _currentFrames = new List<Sprite>();

        public void SetFrame(int frame)
        {
            if (_currentFrames.Count <= 0 || frame < 0 || frame >= _currentFrames.Count) return;

            _spr.sprite = _currentFrames[frame];
        }

        public void SetFrames(List<Sprite> frames)
        {
            _currentFrames = frames;
        }
    }
}