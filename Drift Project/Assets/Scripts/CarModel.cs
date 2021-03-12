using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour
{
    [SerializeField] private GameObject[] carModels;


    private void Awake()
    {
        ChooseCarModel(CarSelection.CarID);
    }

    private void ChooseCarModel(int index)
    {
        Instantiate(carModels[index], transform.position, transform.rotation);
    }
}
