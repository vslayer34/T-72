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

    // to take the input of the player
    float horizontalInput;
    float verticalInput;

    WheelCollider[] wheelColliders = new WheelCollider[4];
    Transform[] wheelMeshes = new Transform[4];

    private void Start()
    {
        // set the colliders of the car
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
        // update the player input
        horizontalInput = Input.GetAxis(InputTagHolder.horizontalInputTag);
        verticalInput = Input.GetAxis (InputTagHolder.verticalInputTag) * -1;
        Debug.Log(verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
            ApplyBrakes();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            UpdateWheelPos(wheelColliders[i], wheelMeshes[i]);
            //MoveVehicle(wheelColliders[i]);
            //SteerVehicle(wheelColliders[i]);
        }

        // move with the 2 back wheels
        MoveVehicle(backLeftCollider, backRightCollider);


        // steer front wheels
        SteerVehicle(frontLeftCollider, frontRightCollider);
    }


    void UpdateWheelPos(WheelCollider wheelCollider, Transform wheelMeshe)
    {
        // get the transform and rotaition of the wheel meshes
        Vector3 colliderPosition = wheelCollider.transform.position;
        Quaternion colliderRotation = wheelCollider.transform.rotation;

        // apply the wheel colliders position and rotation to the wheel mesh
        wheelCollider.GetWorldPose(out colliderPosition, out colliderRotation);

        //wheelMeshe.transform.position = colliderPosition;
        wheelMeshe.transform.rotation = colliderRotation;
    }

    void MoveVehicle(WheelCollider wheel1, WheelCollider wheel2)
    {
        bool moveForward, moveBackward;

        wheel1.motorTorque = brdm2.horsePower * verticalInput;
        wheel2.motorTorque = brdm2.horsePower * verticalInput;

        //Debug.Log(wheel1.attachedRigidbody.velocity.z);

        if (wheel1.attachedRigidbody.velocity.z > 0.0f)
        {
            moveBackward = true;
            moveForward = false;
        }
        else if (wheel1.attachedRigidbody.velocity.z < 0.0f)
        {
            moveBackward = false;
            moveForward = true;
        }
        else
        {
            moveBackward = false;
            moveForward = false;
        }
    }

    void SteerVehicle(WheelCollider wheel1, WheelCollider wheel2)
    {
        wheel1.steerAngle = brdm2.maxSteer * horizontalInput;
        wheel2.steerAngle = brdm2.maxSteer * horizontalInput;
    }

    void ApplyBrakes()
    {
        backLeftCollider.brakeTorque = brdm2.brakePower * 0.3f;
        backRightCollider.brakeTorque = brdm2.brakePower * 0.3f;

        frontLeftCollider.brakeTorque = brdm2.brakePower * 0.7f;
        frontRightCollider.brakeTorque = brdm2.brakePower * 0.7f;
    }
}
