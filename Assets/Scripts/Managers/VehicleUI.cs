using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VehicleUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI vehicleSpeed;
    [SerializeField]
    TrackVehicle vehilceData;


    private void Update()
    {
        vehicleSpeed.text = $"{vehilceData.speed * 3.6f} km/h";
    }
}
