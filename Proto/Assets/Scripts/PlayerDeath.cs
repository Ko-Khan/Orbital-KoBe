using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public void triggerDeathScreen() {
        gameObject.SetActive(true);
    }

    public void restartButton() {
        SceneManager.LoadScene("Tutorial");
    }

    public void quitButton() {
        Application.Quit();
    }
}
