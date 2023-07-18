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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void continueButton() {
        gameObject.SetActive(false);
        player.GetComponent<Health>().Revive();
    }
        
}
