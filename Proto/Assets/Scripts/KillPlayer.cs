using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
    
        if (other.CompareTag("Player")) {
                
        other.GetComponent<Health>().Die();

        other.GetComponent<Animator>().SetBool("IsDead", true);

        other.GetComponent<PlayerMovement>().enabled = false;

        }        

    }
    
}
