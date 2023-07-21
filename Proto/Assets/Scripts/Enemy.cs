using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        GetComponent<Animator>().SetBool("IsDead", false);
        GetComponent<Animator>().ResetTrigger("TakeDamage");
    }

      
    public void TakeDamage(int damage) {
        currentHealth -= damage;
        GetComponent<Animator>().SetTrigger("TakeDamage");

        if (currentHealth <= 0) {
            Die();
        }

    }


    private void Die() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().SetBool("IsDead", true);
        
    }

    private void destroyObject() {
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
}
