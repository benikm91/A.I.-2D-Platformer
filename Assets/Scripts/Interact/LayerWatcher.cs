using UnityEngine;

public abstract class LayerWatcher<T> : MonoBehaviour where T : EventAction
{
    [SerializeField] private float _distance = 1;

    private T _value;
    protected T Value
    {
        get { return _value; }
        private set
        {
            if (_value != value)
            {
                if (_value != null) 
                {
                    if (OnExit != null) OnExit(_value);
                }
                if (value != null)
                {
                    if (OnEnter != null) OnEnter(value);
                }
            }
            _value = value;
        }
    }

    protected abstract int Layer { get; }
    protected virtual Color DebugColor { get { return Color.red; } }

    public event System.Action<T> OnStay;
    public event System.Action<T> OnEnter;
    public event System.Action<T> OnExit;

    void Update()
    {
        var up = (transform.localScale.y > 0) ? transform.up : -transform.up;
        Debug.DrawLine(transform.position, transform.position + -up * _distance, DebugColor);
        var hit = Physics2D.Raycast(transform.position, -up, _distance, 1 << Layer);
        if (hit.collider != null) Value = hit.collider.gameObject.GetComponent<T>();
        else Value = null;

        if (Value != null) 
        {
            if (OnStay != null) OnStay(Value);
        }
    }

    public void Awake()
    {
        OnEnter += (value) => value.OnEnter(gameObject);
        OnExit += (value) => value.OnExit(gameObject);
        OnStay += (value) => value.OnStay(gameObject);
    }

    private void OnDisable()
    {
        Value = null;
    }

    void OnDestroy()
    {
        Value = null; // Trigger leave event
    }

}
