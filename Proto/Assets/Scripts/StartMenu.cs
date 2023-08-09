using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    
    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("StartScreen");
    }

    public void OpenControlsMenu() {
        SceneManager.LoadScene("ControlsScreen");
    }

    public void LoadFirstLevel() {
        SceneManager.LoadScene("Level00");
    }

    public void LoadCreditsScreen() {
        SceneManager.LoadScene("CreditsScreen");
    }
}
