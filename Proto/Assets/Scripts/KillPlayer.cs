using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public Transform respawnPoint;

    public void OnTriggerEnter2D(Collider2D other) {
    
        if (other.GetComponent<BoxCollider2D>().tag == "Player") {
                
        other.GetComponent<BoxCollider2D>().gameObject.GetComponent<Health>().Die();

        other.GetComponent<BoxCollider2D>().gameObject.GetComponent<Respawn>().RespawnGameObject(respawnPoint);

        }        

    }    
    
}
