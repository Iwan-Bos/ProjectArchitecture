using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown screenModeDropdown;
    private Resolution[] resolutions;
    private List<string> resolutionOptions = new List<string>();
    private Dictionary<int, FullScreenMode> screenMode = new Dictionary<int, FullScreenMode>();

    private void Start()  {

        // start the game in fullscreen
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        // get all possible resolutions for this device
        resolutions = Screen.resolutions;
        // clear the current resolutionDropdown options
        resolutionDropdown.ClearOptions();
        
        // convert every Resolution to a string and put it in resolutionOptions
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].ToString();
            resolutionOptions.Add(option);

            // if this is the current screen resolution ; set it as the dropdown index
            if (resolutions[i].ToString() == resolutions[i].ToString()) 
            { 
                resolutionDropdown.value = i; 
            }
        }

        // add the List of options to resolutionDropdown
        resolutionDropdown.AddOptions(resolutionOptions);

        // add the screenMode List items
        screenMode.Add(0, FullScreenMode.ExclusiveFullScreen);
        screenMode.Add(1, FullScreenMode.FullScreenWindow);
        screenMode.Add(2, FullScreenMode.MaximizedWindow);
        screenMode.Add(3, FullScreenMode.Windowed);
    }

    public void SetResolution() {

        Resolution sResolution = resolutions[resolutionDropdown.value];
        FullScreenMode sScreenMode = screenMode[screenModeDropdown.value];

       // set the resolution with the selected values
        Screen.SetResolution(sResolution.width, sResolution.height, sScreenMode, sResolution.refreshRate);
    }
    
    // methods for changing audio mixer values
    public void SetMasterVolume(float volume) { audioMixer.SetFloat("MasterVolume", volume); }
    public void SetMusicVolume(float volume) { audioMixer.SetFloat("MusicVolume", volume); }
    public void SetSFXVolume(float volume) { audioMixer.SetFloat("SFXVolume", volume); }

}
