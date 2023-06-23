using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
    public LayerMask enemyMask;
    public Transform edge;
    public GameObject weapon;


  
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F)) {
        Attack();
       }
    }

   void Attack() {
    weapon.GetComponent<Animator>().SetTrigger("Attack");
    
    Collider2D[] hitenemies = Physics2D.OverlapAreaAll(transform.position, edge.position, enemyMask);

    foreach(Collider2D enemy in hitenemies) {
        enemy.GetComponent<Enemy>().TakeDamage(5);
    }

   }

  void OnDrawGizmosSelected() {
    Gizmos.DrawLine(transform.position, edge.position);
  }
}
