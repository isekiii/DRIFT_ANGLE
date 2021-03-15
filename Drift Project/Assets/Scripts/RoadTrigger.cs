using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    public bool onRoad;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Road")) return;
        onRoad = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Road")) return;
        onRoad = false;
    }
}
