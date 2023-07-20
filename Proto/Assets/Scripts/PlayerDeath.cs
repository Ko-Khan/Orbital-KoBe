using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void triggerDeathScreen() {
        gameObject.SetActive(true);
    }

    public void restartButton() {
        Player.continueOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void continueButton() {
        Player.continueOn = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
}
