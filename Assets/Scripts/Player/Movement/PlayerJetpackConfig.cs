using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/JetpackConfig")]
public class PlayerJetpackConfig : ScriptableObject 
{
    
    [SerializeField] private float _maxFuel = 100;
    public float MaxFuel { get { return _maxFuel; } }
    public float InitFuel { get { return _maxFuel; } }

    [SerializeField] private float _maxSpeed = 5;
    public float MaxSpeed { get { return _maxSpeed; } }

    [SerializeField] private float _refillSpeed = 1;
    public float RefillSpeed { get { return _refillSpeed; } }

    [SerializeField] private float _boost = 20;
    public float Boost { get { return _boost; } }

    [SerializeField] private float _fuelPerBoost = 10;
    public float FuelPerBoost { get { return _fuelPerBoost; } }

}
