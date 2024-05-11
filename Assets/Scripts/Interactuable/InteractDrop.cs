using System.Collections.Generic;
using UnityEngine;

namespace BGS.Interactuable
{
    public class InteractDrop : InteractuableBase
    {
        [Header("Drop Properties")]
        [SerializeField] private List<GameObject> _drops = new List<GameObject>();

        public override void Interact()
        {
            if (_drops.Count <= 0) return;

            Debug.Log("Generate Drop");

            base.Interact();
            GameObject drop = _drops[Random.Range(0, _drops.Count)];
        }
    }
}

