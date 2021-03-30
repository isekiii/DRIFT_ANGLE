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
    [SerializeField] private TMP_Text endText;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private AudioSource finishSound;
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
        endText.text = "!!!FINISH!!!";
        StartCoroutine(startEnd());
    }

    IEnumerator startEnd()
    {
        yield return new WaitForSeconds(1f);
        
        endPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
}
