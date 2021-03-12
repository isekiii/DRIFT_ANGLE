using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private TMP_Text endText;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(count);
        if (other.gameObject.CompareTag("Player"))
        {
            if (count>0) EndGame();
            count++;
            
            
        }
        
    }

    private void Update()
    {
        
    }

    void EndGame()
    {
        Time.timeScale = 0.1f;
        endText.text = "!!!FINISH!!!";

    }
}
