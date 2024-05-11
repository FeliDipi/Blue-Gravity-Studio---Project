﻿using UnityEngine;

namespace BGS.Interactuable
{
    public class InteractuableUI : MonoBehaviour
    {
        [SerializeField] private GameObject _interactuableContent;
        [SerializeField] private TMPro.TextMeshProUGUI _interactuableText;

        public void SetInteraction(IInteractuable interactuable)
        {
            _interactuableContent.SetActive(true);
            _interactuableText.text = interactuable.Info;
        }

        public void OutInteraction()
        {
            _interactuableContent.SetActive(false);
            _interactuableText.text = "";
        }
    }
}

