using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;

    private bool immune;

    public PlayerDeath PlayerDeath;


    // Start is called before the first frame update
    void Start() {
        health = 100;
        immune = false;
    }


    public void Die() {
        this.health = 0;
        PlayerDeath.triggerDeathScreen();
    }

    public void Revive() {
        transform.position = GetComponent<Respawn>().respawnPoint;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsDead", false);
        animator.SetBool("IsIdle", true);
        animator.SetBool("OnGround", true);
        animator.Play("Cowboy_Idle", -1, 0);
        health = 100;
        GetComponent<PlayerMovement>().enabled = true;
    }

}
