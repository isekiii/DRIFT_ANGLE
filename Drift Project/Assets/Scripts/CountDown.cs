using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
public int countdownTime;

public TMP_Text countDownDisplay;

public TimerController timer;

private void Start()
{
    StartCoroutine(CountdownToStart());
}

IEnumerator CountdownToStart()
   {
    while (countdownTime > 0)
    {
        countDownDisplay.text = countdownTime.ToString();

        yield return new WaitForSeconds(1f);

        countdownTime--;
    }

    countDownDisplay.text = "GO";
    timer.BeginTimer();

    
    yield return new WaitForSeconds(1f);
    countDownDisplay.gameObject.SetActive(false);
   }
    
}
