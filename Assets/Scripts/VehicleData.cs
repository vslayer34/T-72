using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vehicle", menuName = "Vehicle Data")]
public class VehicleData : ScriptableObject
{
    public string vehicleName;
    public float horsePower;
    public float brakePower;
    public float maxSteer;

    public float maxSpeed = 90.0f;
    public float maxReverseSpeed = 10.0f;
}
