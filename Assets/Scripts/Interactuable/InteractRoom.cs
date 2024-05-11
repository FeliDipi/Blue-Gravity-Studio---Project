using UnityEngine;
using UnityEngine.SceneManagement;

namespace BGS.Interactuable
{
    public class InteractRoom : InteractuableBase
    {
        [Header("Room Properties")]
        [SerializeField] private string _sceneName = "Main Game";

        public override void Interact()
        {
            base.Interact();

            SceneManager.LoadScene(_sceneName);
        }
    }
}

