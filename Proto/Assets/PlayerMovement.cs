using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollider;
    private float jumpForce = 3.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) {
            myRigidBody.velocity = Vector2.up * 8; 
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            myRigidBody.velocity = Vector2.left * 3;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            myRigidBody.velocity = Vector2.right * 3;
        }
    }
}
