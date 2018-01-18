using UnityEngine;

public abstract class EventAction : MonoBehaviour
{
    public virtual void OnEnter(GameObject go) { }
    public virtual void OnExit(GameObject go) { }
    public virtual void OnStay(GameObject go) { }
}
