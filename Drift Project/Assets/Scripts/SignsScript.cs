using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignsScript : MonoBehaviour
{
    public Rigidbody rb;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            rb.constraints = RigidbodyConstraints.None;
        }
       
    }
}
