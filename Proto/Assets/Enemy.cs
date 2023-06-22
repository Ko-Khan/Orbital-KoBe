using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    private int currentHealth;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

      private void OnTriggerEnter2D(Collider2D other) {
    
        if (other.CompareTag("Player")) {
                
        other.GetComponent<Health>().Die();

        other.GetComponent<Animator>().SetBool("IsDead", true);

        other.GetComponent<PlayerMovement>().enabled = false;

        //other.GetComponent<Respawn>().RespawnGameObject(respawnPoint);

        }        

    }

    // Update is called once per frame
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }

    }



    void Die() {
    Debug.Log("Noooo!!!");
    GetComponent<Collider2D>().enabled = false;
    this.enabled = false;
    
    }
}
