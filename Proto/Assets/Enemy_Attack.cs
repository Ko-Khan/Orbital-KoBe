using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public Animator animator;
    public int attackCooldown;
    public int damage;
    public float range;
    public GameObject Player;
    public LayerMask playerLayer;
    public Transform attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        
      StartCoroutine(Attack());
    
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackCooldown);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
        if (hitPlayer()) 
        {
          Player.GetComponent<Health>().TakeDamage(damage);
        }

    }

    bool hitPlayer() {
     Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, range, playerLayer);
        return hit != null;

    }
}
