using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    
    public AudioMixer audioMixer;


    private void Awake()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
        audioMixer.SetFloat("carVolume", PlayerPrefs.GetFloat("carVolume"));
    }

    public void Playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("MapSwitch");
    }

    public void GoToSettingsMenu()
    {
      //  SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("App closed -_-");
    }
    public void TEST1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
