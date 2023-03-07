using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectVehilceData : MonoBehaviour
{
    [SerializeField]
    TrackVehicle brdm2Record;

    [SerializeField]
    Rigidbody rbRecord;
    // Start is called before the first frame update
    void Start()
    {
        rbRecord = GetComponent<Rigidbody>();
        brdm2Record.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        brdm2Record.speed = rbRecord.velocity.magnitude;
    }
}
