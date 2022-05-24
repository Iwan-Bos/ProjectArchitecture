using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelToggles : MonoBehaviour {

    // Panels;
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;

    // Active on load configuration;
    private void Start() {
        MainPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    
    // UI Toggles;
    // Main panel
    public void OpenMainPanel() { MainPanel.SetActive(true); }
    public void CloseMainPanel() { MainPanel.SetActive(true); }
     // Options panel
    public void OpenOptions() {  
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    public void CloseOptions() {
            OptionsPanel.SetActive(false);
            MainPanel.SetActive(true);
    }
    // Credits panel
    public void OpenCredits() {
            MainPanel.SetActive(false);
            CreditsPanel.SetActive(true);
    }
    public void CloseCredits() {
            CreditsPanel.SetActive(false);
            MainPanel.SetActive(true);
    }
    
    // Misc UI Functions;
    public void QuitGame() { 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void PauseGame() { Time.timeScale = 0.0f; }
    public void ResumeGame() { Time.timeScale = 1.0f; }

}
