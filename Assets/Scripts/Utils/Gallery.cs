using BGS.Apparence;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gallery<T> : MonoBehaviour
{
    [Header("Gallery Properties")]
    [SerializeField] private Transform _grid;

    [SerializeField] private Transform _descriptionContent;

    [Header("Info Properties")]
    [SerializeField] protected TMPro.TextMeshProUGUI _title;

    [SerializeField] protected TMPro.TextMeshProUGUI _rarity;
    [SerializeField] protected TMPro.TextMeshProUGUI _description;

    protected List<Cell> _cells = new List<Cell>();

    protected Cell _cellSelected;
    protected T _manager;

    public void Setup(T manager)
    {
        _manager = manager;

        GetCells();
        UpdateCells();
    }

    private void OnEnable()
    {
        UpdateCells();
    }

    private void GetCells()
    {
        foreach (Transform cell in _grid)
        {
            Cell cellComp = cell.GetComponent<Cell>();
            _cells.Add(cellComp);
        }
    }

    protected abstract void UpdateCells();
    protected abstract void UpdateDescription();

    public virtual void SelectCell(Cell cellSelected)
    {
        _cellSelected = cellSelected;

        UpdateDescription();
    }
}
