using BGS.Market;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MarketCell : ButtonAnimation
{
    public Action<IMarketItem> OnSelect;

    [Header("Cell Properties")]
    [SerializeField] private Image _icon;

    private IMarketItem _marketItem;

    public void SetItem(IMarketItem marketItem)
    {
        _marketItem = marketItem;

        _icon.sprite = _marketItem.ItemData.Icon;
        _icon.gameObject.SetActive(true);
    }

    public override void Click()
    {
        OnSelect?.Invoke(_marketItem);
    }
}
