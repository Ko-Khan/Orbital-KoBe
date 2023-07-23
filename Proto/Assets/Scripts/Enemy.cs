using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isAlive;

    public int maxHealth;

    public int currentHealth;
    
    public Healthbar healthbar;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        isAlive = true;
        GetComponent<Animator>().SetBool("IsDead", false);
        GetComponent<Animator>().ResetTrigger("TakeDamage");
    }

      // Reduces Health, when health <0, trigger Die method
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);

        GetComponent<Animator>().SetTrigger("TakeDamage");

        if (currentHealth <= 0) {
            Die();
        }

    }

   // Begins process of death
    private void Die() {
        isAlive = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().SetBool("IsDead", true);       
        // GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }


   // Called at a specific frame of death animation to destroy gameObject
    private void destroyObject() {
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
}
