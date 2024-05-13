using Cinemachine;
using System.Collections;
using UnityEngine;

namespace BGS.Interactuable
{
    public class InteractPath : InteractuableBase
    {
        [Header("Path Properties")]
        [SerializeField] private Transform _object;

        [SerializeField] private CinemachineVirtualCamera _cam;

        [Header("Path Animation Properties")]
        [SerializeField] private float _delay = 1f;

        private Transform _originalTarget;
        private bool _onSee = false;

        private new void Awake()
        {
            base.Awake();
            _originalTarget = _cam.Follow;
        }

        public override void Interact()
        {
            if (_onSee) return;
            _onSee = true;

            base.Interact();

            StartCoroutine(See());
        }

        private IEnumerator See()
        {
            _cam.Follow = _object;

            yield return new WaitForSeconds(_delay);

            _cam.Follow = _originalTarget;
            _onSee = false;
        }
    }
}