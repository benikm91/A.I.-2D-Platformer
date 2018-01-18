using UnityEngine;

[DisallowMultipleComponent]
public class InteractableWatcher : LayerWatcher<Interactable>
{
    protected override int Layer { get { return LayerMask.NameToLayer("Interactable"); } }
    public Interactable Interactable { get { return Value; } }

}
