using UnityEngine;

public class GravityFlip : Action
{
    public override void Execute(GameObject triggerer) { Physics2D.gravity = -Physics2D.gravity; }
}
