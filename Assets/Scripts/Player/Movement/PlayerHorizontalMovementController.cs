using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(IHorizontalMovementInput))]
public class PlayerHorizontalMovementController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private IHorizontalMovementInput _input;
    [SerializeField] private PlayerHorizontalMovementConfig _config;

    public bool IsMovingLeft { get { return _rb2d.velocity.x < 0; } }
    public bool IsMovingRight { get { return _rb2d.velocity.x > 0; } }

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _input = GetComponent<IHorizontalMovementInput>();
    }

    void FixedUpdate()
    {
        _rb2d.AddForce(transform.right * _input.HorizontalMovementRequest * _config.MoveForce);
        _rb2d.velocity = _rb2d.velocity.ClampX(-_config.MaxSpeed, _config.MaxSpeed);
    }

}
