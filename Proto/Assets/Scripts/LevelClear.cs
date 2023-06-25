using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour {
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<BoxCollider2D>().tag == "Player") {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
