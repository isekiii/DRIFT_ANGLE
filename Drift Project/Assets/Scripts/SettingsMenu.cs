using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public Dropdown resolutionDropDown;
    public Dropdown quality;

    Resolution[] resolutions;

    public Slider masterVolume;
    public Slider carVolume;
    public Toggle fullscreenBox;
    

    void Awake()
    {
       resolutions = Screen.resolutions;
       
       resolutionDropDown.ClearOptions();

       List<string> options = new List<string>();

       int currentResolutionIndex = 0;
       
       for (int i = 0; i < resolutions.Length; i++)
       {
          // string option = resolutions[i].width + "x" + resolutions[i].height + $"  {resolutions[i].refreshRate}hz";
          string option = resolutions[i].width + "x" + resolutions[i].height;
           options.Add(option);

          // if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
         //  {
         //      currentResolutionIndex = i;
         //  }
       }
       
       resolutionDropDown.AddOptions(options);
       //resolutionDropDown.value = currentResolutionIndex;
       resolutionDropDown.RefreshShownValue();
       
       SetVolume(PlayerPrefs.GetFloat("Volume"));
       SetCarVolume(PlayerPrefs.GetFloat("carVolume"));
       SetQuality(PlayerPrefs.GetInt("qualityIndex"));
       if (PlayerPrefs.GetInt("Fullscreen") == 1)
       {
           SetFullscreen(true);
       }
       else SetFullscreen(false);
       
       masterVolume.value = PlayerPrefs.GetFloat("Volume");
       carVolume.value = PlayerPrefs.GetFloat("carVolume");
       quality.value = PlayerPrefs.GetInt("qualityIndex");
       resolutionDropDown.value = PlayerPrefs.GetInt("resolutionIndex");
       
      
    }
 /*
    private void Start()
    {
        masterVolume.value = PlayerPrefs.GetFloat("Volume");
        carVolume.value = PlayerPrefs.GetFloat("carVolume");
        quality.value = PlayerPrefs.GetInt("qualityIndex");
        resolutionDropDown.value = PlayerPrefs.GetInt("resolutionIndex");
    }
*/
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        audioMixer.SetFloat("Volume", volume);
       
    }

    public void SetCarVolume(float volume)
    {
        PlayerPrefs.SetFloat("carVolume", volume);
        audioMixer.SetFloat("carVolume", volume);
    }
    

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else PlayerPrefs.SetInt("Fullscreen", 0);
        
        Screen.fullScreen = isFullscreen;
    }
}
