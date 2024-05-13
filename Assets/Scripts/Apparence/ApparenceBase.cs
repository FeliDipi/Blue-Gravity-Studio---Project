using UnityEngine;

namespace BGS.Apparence
{
    public class ApparenceBase : MonoBehaviour, IApparenceBase
    {
        [SerializeField] private SpriteRenderer _base;

        public int GetCurrentFrame()
        {
            string frameName = _base.sprite.name;
            string frameIndex = frameName.Substring(frameName.LastIndexOf('_') + 1);

            return int.Parse(frameIndex);
        }
    }
}