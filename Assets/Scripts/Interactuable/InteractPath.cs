using System.Collections.Generic;
using UnityEngine;

namespace BGS.Interactuable
{
    public class InteractPath : InteractuableBase
    {
        [Header("Path Properties")]
        [SerializeField] private List<GameObject> _paths = new List<GameObject>();

        public override void Interact()
        {
            base.Interact();

            foreach (var path in _paths) path.SetActive(true);
        }
    }
}

