using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
  public LayerMask enemyMask;
  public Transform edge;
  public int attackingPower;


  void Start() {
    GetComponent<Animator>().ResetTrigger("Attack");
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F)) {
      GetComponent<Animator>().SetTrigger("Attack");
    }
  }

  private void Attack() {
    Collider2D[] hitenemies = Physics2D.OverlapAreaAll(transform.position, edge.position, enemyMask);
     if (hitenemies != null) {
      Debug.Log("Ow");
     }
    foreach(Collider2D enemy in hitenemies) {
      if (enemy.CompareTag("Enemy")) {
        enemy.gameObject.GetComponent<Enemy>().TakeDamage(attackingPower);
      }  
    }
  }

  public void playAttackSound() {
    GameObject.FindWithTag("Audio").GetComponent<AudioManager>().PlaySFX("Attack");
  }

  void OnDrawGizmosSelected() {
    Gizmos.DrawLine(transform.position, edge.position);
  }
}
