using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{

    private Transform player;

    public float speed;

    public float rotateSpeed;

    private Rigidbody2D rb;

    private Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.right).z;

        rb.angularVelocity = rotateAmount *rotateSpeed;

        rb.velocity = -transform.right * -speed;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other == player.GetComponent<Collider2D>())
        {
            player.GetComponent<Health>().TakeDamage(10);
        }
        animator.SetTrigger("Boom");
    }

    void selfDestruct()
    {
        Destroy(gameObject);
    }
}
