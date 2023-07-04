using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;

    private int currentHealth;

    public Healthbar healthbar;

    private bool immune;

    public PlayerDeath PlayerDeath;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        immune = false;
    }


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);

        GetComponent<Animator>().SetTrigger("TakeDamage");

        if (currentHealth <= 0) {
            StartCoroutine(Die());
        }

    }


    public IEnumerator Die() {
        currentHealth = 0;
        healthbar.setHealth(currentHealth);
        GetComponent<Animator>().SetBool("IsDead", true);
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        PlayerDeath.triggerDeathScreen();
    }

    public void Revive() {
        transform.position = GetComponent<Respawn>().respawnPoint;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsDead", false);
        animator.SetBool("IsIdle", true);
        animator.SetBool("OnGround", true);
        animator.Play("Cowboy_Idle", -1, 0);
        currentHealth = 100;
        healthbar.setHealth(currentHealth);
        GetComponent<PlayerMovement>().enabled = true;
    }

}
