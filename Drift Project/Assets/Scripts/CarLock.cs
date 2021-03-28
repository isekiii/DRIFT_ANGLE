using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class CarLock : MonoBehaviour
{
    private VPStandardInput car;
    private GameObject carBody;
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<VPStandardInput>();
        carBody = GameObject.FindGameObjectWithTag("Player");
        car.enabled = false;
        StartCoroutine(enableCar());
    }

    IEnumerator enableCar()
    {
        yield return new WaitForSeconds(3f);
        car.enabled = true;
    }
}
