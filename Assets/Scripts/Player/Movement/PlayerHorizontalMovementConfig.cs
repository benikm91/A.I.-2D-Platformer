using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Movement")]
public class PlayerHorizontalMovementConfig : ScriptableObject 
{

    [SerializeField] private float _moveForce = 365f;
    public float MoveForce { get { return _moveForce;  } }

    [SerializeField] private float _maxSpeed = 5f;
    public float MaxSpeed { get { return _maxSpeed; } }

}
