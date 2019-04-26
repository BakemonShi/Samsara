using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    //Resolution[] resolutions;

    public void Start()
    {
       
        Screen.SetResolution(1280, 720,Screen.fullScreen);
        //resolutionDropdown.value = 0;
        
    }
    public void SetResolution (int resolutionIndex)
    {
        /*Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);*/
        if(resolutionDropdown.value == 0)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
        else if(resolutionDropdown.value == 1)
        {
            Screen.SetResolution(1600, 1200, Screen.fullScreen);
        }
        else if(resolutionDropdown.value == 2)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }


    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen");
    }
}
