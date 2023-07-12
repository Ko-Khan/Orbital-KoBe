using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private int damage; 
    [SerializeField] private float range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private Health playerHealth;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSIght()) 
        {
            if (cooldownTimer >= attackCoolDown) 
            {
               cooldownTimer = 0;
               anim.SetTrigger("Attack");
            }
        }
    }

    private bool PlayerInSIght() 
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x, boxCollider.bounds.size, 0, Vector2.left,
        0, playerLayer);

        if (hit.collider != null) 
        {
            playerHealth = hit.transform.gameObject.GetComponent<Health>();
        }
        
        return hit.collider != null;
        

    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x, boxCollider.bounds.size);
    }

    private void damagePlayer() 
    {
        if (PlayerInSIght())
        {
            playerHealth.TakeDamage(damage);
            playerHealth.Knockback(7, 7, GetComponent<Transform>());

        }
    }
}
