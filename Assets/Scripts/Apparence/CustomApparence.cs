using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    public class CustomApparence : MonoBehaviour
    {
        public string Key = "default";

        [SerializeField] private SpriteRenderer _decoration;

        private List<Sprite> _currentDecoration = new List<Sprite>();

        public void SetFrame(int frame)
        {
            if (_currentDecoration.Count <= 0) return;

            _decoration.sprite = _currentDecoration[frame];
        }

        public void SetDecoration(List<Sprite> decoration)
        {
            _currentDecoration = decoration;
        }
    }
}

