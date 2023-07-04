using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
    
        if (other.CompareTag("Player")) {
                
        Health playerHealth = other.GetComponent<Health>();

        playerHealth.TakeDamage(playerHealth.maxHealth);

       }        

    }
    
}
