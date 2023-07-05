using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float pushForce;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        animator.SetTrigger("Bounce");
        Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();
        playerBody.velocity = new Vector2(playerBody.velocity.x, pushForce);
        
    }
}
