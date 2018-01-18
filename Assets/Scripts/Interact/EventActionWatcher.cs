using UnityEngine;

[DisallowMultipleComponent]
public class EventActionWatcher : LayerWatcher<EventAction>
{
    protected override int Layer { get { return LayerMask.NameToLayer("EventAction"); } }
}
