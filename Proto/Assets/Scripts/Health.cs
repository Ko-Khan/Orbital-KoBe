using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    
    private bool alive;

    private bool immune;

    public PlayerDeath PlayerDeath;


    // Start is called before the first frame update
    void Start() {
        health = 100;
        alive = true;
        immune = false;
    }


    public void Die() {
        this.health = 0;
        PlayerDeath.triggerDeathScreen();
    }

}
