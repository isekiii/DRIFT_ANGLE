using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBrake : MonoBehaviour
{
    public GameObject handbrake;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handbrake.SetActive(true);
        }
        else  handbrake.SetActive(false);
    }
}
