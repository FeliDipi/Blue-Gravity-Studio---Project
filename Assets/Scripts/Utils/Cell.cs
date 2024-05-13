using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : ButtonAnimation
{
    public Action<Cell> OnSelect;

    [Header("Cell Properties")]
    [SerializeField] private Image _itemIcon;

    [SerializeField] private Image _usedIcon;

    private string _itemId;
    private bool _isUsed = false;

    public void SetItem(string itemId, Sprite itemIcon)
    {
        _itemId = itemId;

        _itemIcon.sprite = itemIcon;
        _itemIcon.gameObject.SetActive(true);
    }

    public void SetUsed(bool value)
    {
        _isUsed = value;
        _usedIcon.gameObject.SetActive(value);
    }

    public override void Click()
    {
        if (_isUsed) return;

        OnSelect?.Invoke(this);
    }

    public string GetData() => _itemId;
}