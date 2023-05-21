using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollider;
    private float horizontal;
    private float speed = 8f;
    private float jumpForce = 5f;
    // Start is called before the first frame update
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("space")) {
       myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }


    }


    void FixedUpdate() 
    {
        myRigidBody.velocity = new Vector2(horizontal, myRigidBody.velocity.y);
        
}
}
