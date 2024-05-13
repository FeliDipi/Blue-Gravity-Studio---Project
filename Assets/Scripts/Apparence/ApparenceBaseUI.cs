using UnityEngine;
using UnityEngine.UI;

namespace BGS.Apparence
{
    public class ApparenceBaseUI : MonoBehaviour, IApparenceBase
    {
        [SerializeField] private Image _base;

        public int GetCurrentFrame()
        {
            string frameName = _base.sprite.name;
            string frameIndex = frameName.Substring(frameName.LastIndexOf('_') + 1);

            return int.Parse(frameIndex);
        }
    }
}