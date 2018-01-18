using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Renderer))]
public class DoorController : MonoBehaviour 
{
    Renderer _renderer;
    Collider2D _collider;

    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider2D>();
    }

    public void Open() 
    {
        _renderer.enabled = false;
        _collider.enabled = false;
    }

    public void Close() 
    {
        _renderer.enabled = true;
        _collider.enabled = true;
    }

}
