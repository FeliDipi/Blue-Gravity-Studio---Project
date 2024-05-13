using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BGS.Apparence
{
    public class CustomApparenceUI : MonoBehaviour, IApparenceApplicator
    {
        public ApparenceType Key => _type;

        public List<Sprite> Frames => _currentFrames;

        [SerializeField] private Image _img;
        [SerializeField] private ApparenceType _type;

        private List<Sprite> _currentFrames = new List<Sprite>();

        public void SetFrame(int frame)
        {
            if (_currentFrames.Count <= 0) return;

            _img.sprite = _currentFrames[frame];
        }

        public void SetFrames(List<Sprite> frames)
        {
            _img.enabled = true;

            _currentFrames = frames;
        }
    }
}