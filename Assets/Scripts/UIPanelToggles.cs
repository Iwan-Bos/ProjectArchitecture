using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanelToggles : MonoBehaviour {

    // Panels;
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;
    public bool EscapeToggle = true;

    // Active on load configuration;
    private void Start() {
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    private void Update() {
        // Only recieve input when in the game.
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex (1))
        {
            // Weird pause toggle
            if (Input.GetKeyDown("escape")) { 

                if (EscapeToggle) {  

                    MainPanel.SetActive(true);
                    Time.timeScale = 0.0f;

                    EscapeToggle = false;
                } 
                else {

                    MainPanel.SetActive(false);
                    OptionsPanel.SetActive(false);
                    CreditsPanel.SetActive(false);
                    Time.timeScale = 1.0f;
                    
                    EscapeToggle = true;
                }

            }
        }
    }
    
    // UI Toggles ;
    // Main panel
    public void CloseMainPanel() { 
        MainPanel.SetActive(false); 
        EscapeToggle = true;    
    }
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
    
    // Misc UI Functions ;
    public void StartGame() { 

        SceneManager.LoadScene(1); 
        // Stop("mainMenuMusic");
        // Start("gameMusic");

    }

    public void QuitGame() { 

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

    public void ReturnToMenu() {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }

}
