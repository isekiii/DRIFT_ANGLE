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

    bool isDrifting = false;

    float driftAngle;

    public Speedometer speedometer;

    public TMP_Text currentText, totalText;


    void Update()
    {
       driftAngle = Vector3.Angle(car.velocity, car.transform.forward);
       
        isDrifting = driftAngle > 15 && speedometer.vehicleSpeed > 10 && roadTrigger.onRoad;
        
        UpdateScore();
        UpdateText();
        
        
    }

    void UpdateScore()
    {
        if (isDrifting)
        {
            currentScore += driftAngle * speedometer.vehicleSpeed / 100;
        }
        else
        {
            totalScore += currentScore;
            currentScore = 0;
        }
    }

    void UpdateText()
    {
        if (currentScore > 0)
        {
            currentText.text = currentScore.ToString("0");
        }
        else currentText.text = "";

        totalText.text ="Total score: " +  totalScore.ToString("0");
    }
}
