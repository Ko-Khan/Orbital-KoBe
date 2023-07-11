using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int attackingPower;

    private void OnTriggerEnter2D(Collider2D other) {
    
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<Health>().TakeDamage(attackingPower);        
        }        

    }
}
