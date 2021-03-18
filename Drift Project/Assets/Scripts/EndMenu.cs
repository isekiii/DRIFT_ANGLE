using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text timeEnd;
    [SerializeField] private TMP_Text scoreEnd;

    private TimerController timer;
    private PointSystem score;
    private void Start()
    {
        timer = GameObject.FindObjectOfType<TimerController>();
        score = GameObject.FindObjectOfType<PointSystem>();
    }

    private void Update()
    {
        timeEnd.text = timer.timePlaying.ToString("mm':'ss'.'ff");
        scoreEnd.text = score.totalScore.ToString();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
