using UnityEngine;

namespace BGS.Interactuable
{
    public class InteractRoom : InteractuableBase
    {
        [Header("Room Properties")]
        [SerializeField] private string _sceneName = "Main Game";

        public override void Interact()
        {
            base.Interact();

            Transition.Instance?.FadeIn(_sceneName);
        }
    }
}