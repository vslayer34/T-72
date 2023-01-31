using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vehicle", menuName = "Vehicle Data")]
public class VehicleData : ScriptableObject
{
    public string name;
    public float horsePower;
    public float brakePower;
    public float maxSteer;
}
