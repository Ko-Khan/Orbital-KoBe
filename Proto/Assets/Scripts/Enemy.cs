using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    private int currentHealth;


    // Start is called before the first frame update
    void Start() {
        currentHealth = health;
        GetComponent<Animator>().SetBool("IsDead", false);
        GetComponent<Animator>().ResetTrigger("TakeDamage");
        
        if (gameObject.CompareTag("FollowingEnemy")) {
            StartCoroutine(WakeUp());
        }
    }

      

    // Update is called once per frame
    public void TakeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log("Current Health" + currentHealth);

        GetComponent<Animator>().SetTrigger("TakeDamage");

        if (currentHealth <= 0) {
            StartCoroutine(Die());
        }

    }


    private IEnumerator WakeUp() {
        yield return new WaitForSeconds(5f);
        GetComponent<Pathfinding.AIPath>().enabled = true;
    }



    private IEnumerator Die() {

    GetComponent<Collider2D>().enabled = false;

    GetComponent<Animator>().SetBool("IsDead", true);

    GetComponent<WayPointFollower>().enabled = false; 
    
    if (gameObject.CompareTag("FollowingEnemy")) {
        GetComponent<Pathfinding.AIPath>().enabled = false;
    }

    yield return new WaitForSeconds(1.5f);

    GetComponent<SpriteRenderer>().enabled = false;

    Destroy(gameObject);

    }
}
