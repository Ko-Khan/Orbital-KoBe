using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    
    public void StartGame() {
        SceneManager.LoadScene("Tutorial");
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("StartScreen");
    }

    public void OpenControlsMenu() {
        SceneManager.LoadScene("ControlsScreen");
    }
}
