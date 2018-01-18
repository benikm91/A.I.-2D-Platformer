using UnityEngine;

[DisallowMultipleComponent]
public class LookDownGroundedController : MonoBehaviour, IGroundedController
{

    [SerializeField] private Transform _groundCheckPoint;

    public event System.Action HitGround;
    public event System.Action LeaveGround;

    private bool _grounded = false;

    public bool Grounded
    {
        get { return _grounded; }
        protected set
        {
            if (_grounded != value)
            {
                if (value) 
                {
                    if (HitGround != null) HitGround();
                }
                else 
                {
                    if (LeaveGround != null) LeaveGround();
                }
            }
            _grounded = value;
        }
    }

    void Update()
    {
        Grounded = Physics2D.Linecast(transform.position, _groundCheckPoint.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
