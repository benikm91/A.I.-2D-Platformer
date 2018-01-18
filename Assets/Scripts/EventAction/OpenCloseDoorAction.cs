using UnityEngine;

public class OpenCloseDoorAction : EventAction
{
    [SerializeField] private DoorController _door;

    public override void OnEnter(GameObject go) { _door.Open(); }
    public override void OnExit(GameObject go) { _door.Close(); }
}
