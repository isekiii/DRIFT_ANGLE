using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
     public GameObject needle;

     private float startPosition = 220f, endPosition = -41;

     private float desiredPosition;

     public float vehicleSpeed;

     public Rigidbody vehicle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void FixedUpdate()
    {
        vehicleSpeed = vehicle.velocity.magnitude * 3.6f;
        updateNeedle();
    }

    public void updateNeedle()
    {
        desiredPosition = startPosition - endPosition;
        float temp = vehicleSpeed / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));
    }
}
