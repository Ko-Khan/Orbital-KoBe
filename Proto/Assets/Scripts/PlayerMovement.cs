using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollider;
    private float horizontal;
    private float speed = 16f;
    private float jumpForce = 8f;
    private bool isFacingRight = true;
    private bool jump = false;
    // Start is called before the first frame update
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");

        flip();

        if (Input.GetKeyDown("space") && !jump ) {
            jump = true;
       myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }


    }


    void FixedUpdate() 
    {
        jump = false;
        myRigidBody.velocity = new Vector2(horizontal, myRigidBody.velocity.y);
        
}

   private void flip() {
    if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0) {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

    }
   }

   
}
