using DG.Tweening;
using UnityEngine;

namespace BGS.Interactuable
{
    public abstract class InteractuableBase : MonoBehaviour, IInteractuable
    {
        public string Info => _info;

        [Header("Interactuable Properties")]
        [SerializeField] private string _info = "use";

        [Header("Highlight Properties")]
        [SerializeField] protected float _animationTime = 0.2f;

        [SerializeField] private Vector3 _scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

        private Vector3 _originalScale;

        protected void Awake()
        {
            _originalScale = transform.localScale;
        }

        public virtual void Interact()
        { }

        public void StartHighlight()
        {
            Vector3 newScale = _originalScale + _scaleFactor;
            transform.DOScale(newScale, _animationTime).SetEase(Ease.InOutBack);
        }

        public void StopHighlight()
        {
            transform.DOScale(_originalScale, _animationTime).SetEase(Ease.InOutBack);
        }
    }
}