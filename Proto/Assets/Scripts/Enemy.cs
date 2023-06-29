using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    private int currentHealth;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start() {
        currentHealth = health;
    }

      

    // Update is called once per frame
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        GetComponent<Animator>().SetTrigger("TakeDamage");

        if (currentHealth <= 0) {
            StartCoroutine(Die());
        }

    }



    private IEnumerator Die() {

    GetComponent<Collider2D>().enabled = false;

    GetComponent<WayPointFollower>().enabled = false;

    GetComponent<Animator>().SetBool("IsDead", true);

    GetComponent<SpriteRenderer>().enabled = false;

    Destroy(gameObject);

    yield return new WaitForSeconds(1f);

    GetComponent<SpriteRenderer>().enabled = false;

    Destroy(gameObject);
    
    }
}
