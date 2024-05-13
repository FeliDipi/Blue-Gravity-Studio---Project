using UnityEngine;
using UnityEngine.Events;

namespace BGS.Interactuable
{
    public class InteractEvent : InteractuableBase
    {
        [SerializeField] private UnityEvent _event;

        public override void Interact()
        {
            base.Interact();

            _event?.Invoke();
        }
    }
}