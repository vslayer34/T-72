using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWheelMovemet : MonoBehaviour
{
    [SerializeField]
    WheelCollider[] wheelColliders;

    [SerializeField]
    Transform[] wheelMeshes;

    [SerializeField]
    VehicleData brdm2;

    float horizontalInput;
    float verticalInput;

    WheelCollider frontLeftWheel;
    WheelCollider frontRightWheel;

    private void Start()
    {
        frontLeftWheel = wheelColliders[0];
        frontRightWheel = wheelColliders[3];
    }

    void Update()
    {
        horizontalInput = Input.GetAxis(InputTagHolder.horizontalInputTag);
        verticalInput = Input.GetAxis (InputTagHolder.verticalInputTag);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            UpdateWheelPos(wheelColliders[i], wheelMeshes[i]);
            MoveVehicle(wheelColliders[i]);

            if (wheelColliders[i] == frontRightWheel || wheelColliders[i] == frontLeftWheel)
            {
                SteerVehicle(wheelColliders[i]);
            }
        }
    }


    void UpdateWheelPos(WheelCollider wheelCollider, Transform wheelMeshe)
    {
        Vector3 colliderPosition = wheelCollider.transform.position;
        Quaternion colliderRotation = wheelCollider.transform.rotation;

        wheelCollider.GetWorldPose(out colliderPosition, out colliderRotation);

        //wheelMeshe.transform.position = colliderPosition;
        wheelMeshe.transform.rotation = colliderRotation;
    }

    void MoveVehicle(WheelCollider wheel)
    {
        wheel.motorTorque = brdm2.horsePower * -verticalInput;
    }

    void SteerVehicle(WheelCollider wheel)
    {
        wheel.steerAngle = brdm2.maxSteer * horizontalInput;
    }
}
