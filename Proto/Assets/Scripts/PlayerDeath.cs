using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public GameObject player;

    public void triggerDeathScreen() {
        gameObject.SetActive(true);
    }

    public void restartButton() {
        gameObject.SetActive(false);
        player.GetComponent<Health>().Revive();
    }
        

    public void quitButton() {
        Application.Quit();
    }
}
