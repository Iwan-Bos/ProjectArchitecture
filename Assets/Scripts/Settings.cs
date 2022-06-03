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
    Resolution[] resolutions;
    List<string> resolutionOptions = new List<string>();
    Dictionary<int, FullScreenMode> screenMode = new Dictionary<int, FullScreenMode>();
    int resolutionIndex = 0;

    private void Start() 
    {
        // Gets all possible resolutions for this device and puts it in Resolution[] (an array of the Type Resolution) ;
        // Converts every Resolution to a string and puts it in a List<string> ;
        // Adds the List<string> of options to the resolutionDropdown ;
        // If This is the current screen resolution sets it as the dropdown index ;
        
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].ToString();
            resolutionOptions.Add(option);

            if (resolutions[i].ToString() == Screen.currentResolution.ToString()) { resolutionIndex = i; }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = resolutionIndex;

        screenMode.Add(0, FullScreenMode.ExclusiveFullScreen);
        screenMode.Add(1, FullScreenMode.FullScreenWindow);
        screenMode.Add(2, FullScreenMode.MaximizedWindow);
        screenMode.Add(3, FullScreenMode.Windowed);
    }
    public void SetMasterVolume(float volume) { audioMixer.SetFloat("MasterVolume", volume); }
    public void SetMusicVolume(float volume) { audioMixer.SetFloat("MusicVolume", volume); }
    public void SetSFXVolume(float volume) { audioMixer.SetFloat("SFXVolume", volume); }

    public void SetResolution() {
        Resolution selectedResolution = resolutions[resolutionIndex];
        FullScreenMode selectedScreenMode = screenMode[screenModeDropdown.value];
        Screen.SetResolution(selectedResolution.height, selectedResolution.width, selectedScreenMode, selectedResolution.refreshRate);
    }
}
