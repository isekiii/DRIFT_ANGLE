using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PointSystem : MonoBehaviour
{


    public Rigidbody car;
    public RoadTrigger roadTrigger;

    float currentScore;
    public float totalScore;
    private float streakMeter = 1f;
    private bool streakBoosted = false;
    
    

    private float lastDriftTime;
    private float currentTime;

    bool isDrifting = false;

    float driftAngle;

    public Speedometer speedometer;

    public TMP_Text currentText, totalText;


    void Update()
    {
        currentTime = Time.time;
        
       driftAngle = Vector3.Angle(car.velocity, car.transform.forward);

       if (driftAngle > 90 ) driftAngle = 0;
       
        isDrifting = driftAngle > 15 && speedometer.vehicleSpeed > 10 && roadTrigger.onRoad;

        if (driftAngle < 5 ) 
        {
            StartCoroutine(Drift());
        }
        
        UpdateScore();
        UpdateText();
        
        
    }

    IEnumerator Drift()
    {
        yield return new WaitForSeconds(1f);
        if (currentTime - lastDriftTime < 1f)
        {
            if (!streakBoosted && !isDrifting)
            {
                streakMeter ++;
                streakBoosted = true;
                yield return new WaitForSeconds(1f);
                streakBoosted = false;
            }
            
        } 
    }
    void UpdateScore()
    {
        if (isDrifting)
        {
            currentScore += streakMeter * driftAngle * speedometer.vehicleSpeed / 100;
            lastDriftTime = Time.time;
            streakBoosted = false;
        }
        else
        {
            StartCoroutine(Drift());
            if (currentTime - lastDriftTime > 1f)
            {
                totalScore += currentScore;
                currentScore = 0;
                streakMeter = 1f;
            }  
        }
    }

    void UpdateText()
    {
        if (currentScore > 0)
        {
            currentText.text =$"{streakMeter}x {currentScore.ToString("0")} ";
        }
        else currentText.text = "";

        totalText.text ="Total score: " +  totalScore.ToString("0");
    }
}
