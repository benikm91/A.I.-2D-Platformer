using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(IGroundedController))]
[RequireComponent(typeof(PlayerHorizontalMovementController), typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    
    public bool FacingRight { get { return transform.localScale.x > 0; } }
    public bool FacingLeft { get { return transform.localScale.x < 0; } }

    public bool UpRight { get { return transform.localScale.y > 0; } }
    public bool Turned { get { return transform.localScale.y < 0; } }

    private Animator _anim;
    private Rigidbody2D _rb2d;

    private IGroundedController _grounded;

    private PlayerJetpackController _jetpack;
    private PlayerInputController _input;
    private PlayerHorizontalMovementController _movement;
    private PlayerController _playerController;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();

        _grounded = GetComponent<IGroundedController>();

        _jetpack = GetComponent<PlayerJetpackController>();
        _input = GetComponent<PlayerInputController>();
        _movement = GetComponent<PlayerHorizontalMovementController>();
        _playerController = GetComponent<PlayerController>();

        _grounded.HitGround += () => _anim.SetBool("grounded", true);
        _grounded.LeaveGround += () => _anim.SetBool("grounded", false);
    }

    void FixedUpdate()
    {
        if (_movement.IsMovingRight && FacingLeft || _movement.IsMovingLeft && FacingRight)
            FlipHorizontal();

        if (Physics2D.gravity.y < 0 && Turned || Physics2D.gravity.y > 0 && UpRight) FlipVertical();

        _anim.SetBool("jetpackUse", _input.BoostRequest && _jetpack.Fuel > 0);

        _anim.SetFloat("velocityX", Mathf.Abs(_rb2d.velocity.x));
        _anim.SetFloat("velocityY", Mathf.Abs(_rb2d.velocity.y));
    }

    void FlipVertical() 
    {
        transform.localScale = new Vector3(
            transform.localScale.x,
            -transform.localScale.y,
            transform.localScale.z
        );
    }

    void FlipHorizontal()
    {
        transform.localScale = new Vector3(
            -transform.localScale.x, 
            transform.localScale.y, 
            transform.localScale.z
        );
    }
}