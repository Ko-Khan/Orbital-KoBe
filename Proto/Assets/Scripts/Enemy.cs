using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public Healthbar healthbar;
    public bool isAlive;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        isAlive = true;
        GetComponent<Animator>().SetBool("IsDead", false);
        GetComponent<Animator>().ResetTrigger("TakeDamage");
    }

      
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);

        GetComponent<Animator>().SetTrigger("TakeDamage");

        if (currentHealth <= 0) {
            Die();
        }

    }


    private void Die() {
        isAlive = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().SetBool("IsDead", true);       
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void destroyObject() {
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
}
