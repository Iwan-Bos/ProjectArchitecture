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
    public void OpenMainPanel() {
        MainPanel.SetActive(true);
    }
    public void OpenOptions() {
        if (OptionsPanel != null) {
            MainPanel.SetActive(false);
            OptionsPanel.SetActive(true);
        }
    }
    public void CloseOptions() {
        if (MainPanel != null) {
            OptionsPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
    }
    public void OpenCredits() {
        if (CreditsPanel != null) {
            MainPanel.SetActive(false);
            CreditsPanel.SetActive(true);
        }
    }
    public void CloseCredits() {
        if (CreditsPanel != null) {
            CreditsPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
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
