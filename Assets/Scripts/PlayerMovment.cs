using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _anim;

    private Vector2 _movmentDirection;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movmentDirection.x = Input.GetAxisRaw("Horizontal");
        _movmentDirection.y = Input.GetAxisRaw("Vertical");

        _anim.SetFloat("xMovment", _movmentDirection.x);
        _anim.SetFloat("yMovment", _movmentDirection.y);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movmentDirection.normalized * _speed * Time.fixedDeltaTime);
    }
}