using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWheelMovemet : MonoBehaviour
{
    [SerializeField]
    WheelCollider frontLeftCollider, frontRightCollider, backLeftCollider, backRightCollider;

    [SerializeField]
    Transform frontLeftMesh, frontRigtMesh, backLeftMesh, backRightMesh;

    [SerializeField]
    VehicleData brdm2;

    float horizontalInput;
    float verticalInput;

    WheelCollider[] wheelColliders = new WheelCollider[4];
    Transform[] wheelMeshes = new Transform[4];

    private void Start()
    {
        wheelColliders[0] = frontLeftCollider;
        wheelColliders[1] = frontRightCollider;
        wheelColliders[2] = backLeftCollider;
        wheelColliders[3] = backRightCollider;

        wheelMeshes[0] = frontLeftMesh;
        wheelMeshes[1] = frontRigtMesh;
        wheelMeshes[2] = backLeftMesh;
        wheelMeshes[3] = backRightMesh;
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
            //MoveVehicle(wheelColliders[i]);
            //SteerVehicle(wheelColliders[i]);
        }

        SteerVehicle(frontLeftCollider);
        SteerVehicle(frontRightCollider);
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
