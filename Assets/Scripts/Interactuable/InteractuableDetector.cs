using UnityEngine;

namespace BGS.Interactuable
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InteractuableDetector : MonoBehaviour
    {
        [Header("UI Dependencies")]
        [SerializeField] private InteractuableUI _interactuableUI;

        [Header("Detection Properties")]
        [SerializeField] private float _detectionRadius = 1.5f;

        [SerializeField] private CircleCollider2D _cl;

        private IInteractuable _currentInteractuable;

        private void Awake()
        {
            _cl.isTrigger = true;
            _cl.radius = _detectionRadius;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _currentInteractuable?.Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_currentInteractuable != null || collision.GetComponent<IInteractuable>() == null) return;

            _currentInteractuable = collision.GetComponent<IInteractuable>();
            _currentInteractuable.StartHighlight();

            _interactuableUI.SetInteraction(_currentInteractuable);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_currentInteractuable == null) return;

            _currentInteractuable.StopHighlight();
            _currentInteractuable = null;

            _interactuableUI.OutInteraction();
        }
    }
}