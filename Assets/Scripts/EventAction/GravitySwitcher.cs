using UnityEngine;

[DisallowMultipleComponent]
public class GravitySwitcher : EventAction
{
    public override void OnEnter(GameObject go) { 
        if (go.tag == "Player") Physics2D.gravity = -Physics2D.gravity; 
    }
}
