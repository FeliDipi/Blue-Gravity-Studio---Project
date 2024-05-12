using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BGS.Market
{
    public class MarketPreview : MonoBehaviour
    {
        [SerializeField] private Image _player;
        [SerializeField] private List<Sprite> _sides = new List<Sprite>();

        public void SelectView(int side)
        {
            if (side < 0 || side >= _sides.Count) return;

            _player.sprite = _sides[side];
        }
    }
}

