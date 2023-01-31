using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWheelMovemet : MonoBehaviour
{
    [SerializeField]
    WheelCollider[] wheelColliders;

    [SerializeField]
    Transform[] wheelMeshes;

    void FixedUpdate()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            UpdateWheelPos(wheelColliders[i], wheelMeshes[i]);
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
}
