using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadCheck : MonoBehaviour
{
    public GameObject[] wheels;
    public bool isOnRoad;

    private RaycastHit hit;
    public LayerMask groundLayer;
    public float chkDst = 1f;

    private void Update()
    {
        isOnRoad = Physics.Raycast(transform.position, transform.up * -1, chkDst, groundLayer);
        Debug.DrawRay(transform.position,transform.up * -1 * chkDst, Color.red);
        
        
    }



}
