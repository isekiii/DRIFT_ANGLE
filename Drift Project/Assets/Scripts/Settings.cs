using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public RectTransform optionsPanel;
    
    public TMP_Dropdown RezDropdown;
    public TMP_Dropdown quality;

    private Resolution[] resolutions;

    public Slider masterVolume;
    public Slider carVolume;
    public Toggle fullscreenBox;
    
    void Start()
    {
        RezDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        var rezList = new List<string>();
        foreach (Resolution rez in resolutions)
        {
            string r = $"{rez.width}x{rez.height} {rez.refreshRate}hz";
            rezList.Add(r);
        }

        RezDropdown.AddOptions(rezList);
        
        SetValues();
        
    }

    public void SetValues()
    {
        if (PlayerPrefs.GetInt("Fullscreen") == 1)
        {
            SetFullscreen(true);
        }
        else SetFullscreen(false);
        masterVolume.value = PlayerPrefs.GetFloat("Volume");
        carVolume.value = PlayerPrefs.GetFloat("carVolume");
        quality.value = PlayerPrefs.GetInt("qualityIndex");
        RezDropdown.value = PlayerPrefs.GetInt("resolutionIndex");
    }
    
    
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

    public void GoBack()
    {
        optionsPanel.localScale = new Vector3(0, 0, 0);
    }
    
}
