using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
  public LayerMask enemyMask;
  public Transform edge;
  public int attackingPower;
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
     if (hitenemies != null) {
      Debug.Log("Ow");
     }
    foreach(Collider2D enemy in hitenemies) {
      if (enemy.CompareTag("Enemy")) {
        enemy.GetComponent<Enemy>().TakeDamage(attackingPower);
      } else if (enemy.CompareTag("FollowingEnemy")) {
        enemy.GetComponent<FollowingEnemy>().TakeDamage(attackingPower);
      } 
    }
  }

  void OnDrawGizmosSelected() {
    Gizmos.DrawLine(transform.position, edge.position);
  }
}
