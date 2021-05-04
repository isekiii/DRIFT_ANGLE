using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class CarExhaust : MonoBehaviour
{
    
     float engineRevs;
    public float exhaustRate;
    public Rigidbody car;

    public ParticleSystem exhaust;


    void Start () {
      //  exhaust = GetComponent<ParticleSystem>();
    }
    

    void Update () {
        engineRevs = 1 + car.velocity.magnitude * 3.6f;
        
        exhaust.emissionRate = engineRevs * exhaustRate   ;
    }
    
}
