using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    private int count = 1;
    [SerializeField] private int passCount = 1;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private AudioSource finishSound;

    [SerializeField] private GameObject carImage1;
    [SerializeField] private GameObject carImage2;
    [SerializeField] private GameObject carImage3;
    [SerializeField] private GameObject carImage4;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(count);
        if (other.gameObject.CompareTag("Player"))
        {
            if (count>passCount) EndGame();
            count++;
        }
        
    }


    void EndGame()
    {
        finishSound.Play();
        StartCoroutine(startEnd());
    }

    IEnumerator startEnd()
    {
        yield return new WaitForSeconds(1f);
        
        endPanel.SetActive(true);
        if(CarSelection.CarID == 0)
        {
            carImage1.SetActive(true);
        }
        else if (CarSelection.CarID == 1)
        {
            carImage2.SetActive(true);
        }
        else if(CarSelection.CarID == 2)
        {
            carImage3.SetActive(true);
        }
        else if (CarSelection.CarID == 3)
        {
            carImage4.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    
}
