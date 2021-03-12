using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    public static int CarID { get; private set; }
    public void SetID(int index)
    {
        CarID = index;
    }

    public int GetID()
    {
        return CarID;
    }
}
