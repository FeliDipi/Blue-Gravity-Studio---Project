using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Animation Properties")]
    [SerializeField] private float _animationTime = 0.1f;

    [SerializeField] private Vector3 _rotationShakeFactor = new Vector3(0, 0, 45);
    [SerializeField] private Vector3 _scaleFactor = new Vector3(-0.1f, -0.1f, -0.1f);

    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOShakeRotation(_animationTime, _rotationShakeFactor).SetEase(Ease.InOutBack);

        Click();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 newScale = _originalScale + _scaleFactor;

        transform.DOScale(newScale, _animationTime).SetEase(Ease.InOutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_originalScale, _animationTime).SetEase(Ease.InOutBack);
    }

    public abstract void Click();
}