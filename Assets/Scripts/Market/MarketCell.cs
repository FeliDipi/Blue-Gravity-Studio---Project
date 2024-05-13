using BGS.MarketModule;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MarketCell : ButtonAnimation
{
    public Action<MarketCell> OnSelect;

    [Header("Cell Properties")]
    [SerializeField] private Image _icon;

    [SerializeField] private Image _sold;

    private IMarketItem _marketItem;
    private bool _isSold = false;

    public void SetItem(IMarketItem marketItem)
    {
        _marketItem = marketItem;

        _icon.sprite = _marketItem.Data.Icon;
        _icon.gameObject.SetActive(true);
    }

    public void SetSold()
    {
        _isSold = true;
        _sold.gameObject.SetActive(true);
    }

    public override void Click()
    {
        if (_isSold) return;

        OnSelect?.Invoke(this);
    }

    public IMarketItem GetData() => _marketItem;
}