using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    private bool isReset = false;

    void Update()
    {
        if (!isReset && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(resetCar());
        }
    }
    

    IEnumerator resetCar()
    {
        Vector3 newPos = gameObject.transform.position;
        newPos.y += 2;
        gameObject.transform.position = newPos;
        isReset = true;
        yield return new WaitForSeconds(1.5f);
        isReset = false;
    }
}
