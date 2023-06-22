using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask enemyMask;
    public Transform edge;
    

    
    

    // Update is called once per frame

    void Start() {
        

    }


    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F)) {
        Attack();
       }
    }

   void Attack() {
    
    Collider2D[] hitenemies = Physics2D.OverlapAreaAll(transform.position, edge.position, enemyMask);

    foreach(Collider2D enemy in hitenemies) {
        enemy.GetComponent<Enemy>().TakeDamage(5);
    }

   }

  void OnDrawGizmosSelected() {
    Gizmos.DrawLine(transform.position, edge.position);
  }
}
