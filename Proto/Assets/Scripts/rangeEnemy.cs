using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemy : MonoBehaviour
{

    private GameObject target;

    public GameObject projectile;

    public float range;

    public LayerMask playerMask;

    public float reloadTime;

    private float shootTime;

    private Animator animator;

    public bool isFacingRight;

    private float change;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();

        if (isFacingRight)
        {
            change = -1f;
        } else {
            change = 1f;
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (target.GetComponent<Transform>().position.x > transform.x ) 
        {
           projectile.GetComponent<projectile>()
        } */
        
        if (PlayerInSight())
        {
        if (Time.time > shootTime)
        {
            projectile.GetComponent<Projectile>().setDirection(transform.localScale.x * -1f * change);
            animator.SetTrigger("Shoot");
            shootTime = Time.time + reloadTime;
        }
        }
    }

    bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x * change, 
        range, playerMask);

        return hit.collider != null;

    }

    void Shoot() 
    {
    Instantiate(projectile, transform.position, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * transform.localScale.x * range * change);
    }
}
