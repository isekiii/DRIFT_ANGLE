using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    private bool Wkey = false;
    private bool Skey = false;
    private bool Akey = false;
    private bool Dkey = false;
    private bool SPACEkey = false;
    private bool Speed1 = false;
    private bool Speed2 = false;
    private bool Points1 = false;
    private bool Points2 = false;
    private bool Streak1 = false;
    private bool Streak2 = false;
    private bool T1 = false;
    private bool T2 = false;
    private bool T3 = false;
    private bool T4 = false;
    [SerializeField] private GameObject task1, task2, task3, task4;
    [SerializeField] private TMP_Text W, A, S, D, SPACE, s1, s2, p1, p2, st1, st2;
    [SerializeField] private Speedometer speedometer;
    [SerializeField] private PointSystem pointSystem;
    [SerializeField] private GameObject completed;
    
    
    void Update()
    {
        //--------------------------------
        // Task 1
        //------------------------------------------

        if (!T1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CompleteTask(W);
                Wkey = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                CompleteTask(A);
                Akey = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                CompleteTask(S);
                Skey = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                CompleteTask(D);
                Dkey = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CompleteTask(SPACE);
                SPACEkey = true;
            }

            if (Wkey && Akey && Skey && Dkey && SPACEkey)
            {
                T1 = true;
                task2.SetActive(true);
                task1.SetActive(false);
            }
        }
        
        //--------------------------------------
        // Task 2
        //-------------------------------------

        if (T1 && !T2)
        {
            
            if (speedometer.vehicleSpeed > 30)
            {
                CompleteTask(s1);
                Speed1 = true;
            }
            if (speedometer.vehicleSpeed > 60)
            {
                CompleteTask(s2);
                Speed2 = true;
            }

            if (Speed1 && Speed2 )
            {
                T2 = true;
                task3.SetActive(true);
                task2.SetActive(false);
            }
        }
        
        //--------------------------------------
        // Task 3
        //-------------------------------------

        if (T2 && !T3)
        {
            
            if (pointSystem.totalScore > 20000)
            {
                CompleteTask(p1);
                Points1 = true;
            }
            if (pointSystem.totalScore > 100000)
            {
                CompleteTask(p2);
                Points2 = true;
            }

            if (Points1 && Points2 )
            {
                T3 = true;
                task4.SetActive(true);
                task3.SetActive(false);
            }
        }
        
        
        //--------------------------------------
        // Task 4
        //-------------------------------------

        if (T3 && !T4)
        {
            
            if (pointSystem.streakMeter > 4)
            {
                CompleteTask(st1);
                Streak1 = true;
            }
            if (pointSystem.streakMeter > 8)
            {
                CompleteTask(st2);
                Streak2 = true;
            }

            if (Streak1 && Streak2 )
            {
                T4 = true;
                completed.SetActive(true);
                task4.SetActive(false);
            }
        }
        
        
    }

    void CompleteTask(TMP_Text task)
    {
        task.color = Color.green;
    }
}
