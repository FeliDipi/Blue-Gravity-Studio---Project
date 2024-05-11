using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketPreview : MonoBehaviour
{
    [SerializeField] private List<ButtonEvent> _views = new List<ButtonEvent>();
    [SerializeField] private Image _player;
    [SerializeField] private Image _clothe;
    [SerializeField] private Image _haircut;

    private void Awake()
    {
        SetupViews();
    }

    private void SetupViews()
    {
        for(int i=0;i<_views.Count;i++)
        {
            _views[i].OnClick = () => SelectView(i);
        }
    }

    private void SelectView(int viewIndex) 
    {

    }
}
