using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(IGroundedController), typeof(IJetpackInput))]
public class PlayerJetpackController : MonoBehaviour
{

    [SerializeField] private PlayerJetpackConfig _config;

    private Rigidbody2D _rb2d;
    private IGroundedController _grounded;
    private IJetpackInput _input;
    private float _fuel;
    public float Fuel
    {
        get { return _fuel; }
        set { _fuel = value.Clamp(0, _config.MaxFuel); }
    }

    private void Awake()
    {
        _input = GetComponent<IJetpackInput>();
        _rb2d = GetComponent<Rigidbody2D>();
        _grounded = GetComponent<IGroundedController>();
        Fuel = _config.InitFuel;
    }

    void FixedUpdate()
    {
        if (_grounded.Grounded)
        {
            Fuel = (Fuel + _config.RefillSpeed * Time.deltaTime);
        }

        if (_input.BoostRequest && Fuel > 0 && Mathf.Abs(_rb2d.velocity.y) < _config.MaxSpeed)
        {
            var up = (transform.localScale.y > 0) ? transform.up : -transform.up;
            _rb2d.AddForce(up * _config.Boost);
            Fuel -= _config.FuelPerBoost;
        }
    }

}
