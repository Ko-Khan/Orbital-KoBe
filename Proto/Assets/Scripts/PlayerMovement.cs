using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Deals with gravity, mass and others;
    private Rigidbody2D myRigidBody;

    private BoxCollider2D myBoxCollider;
    
    // Direction the Player is going towards;
    private float horizontal;
    
    public float walkingSpeed;
    
    public float jumpForce;
    
    public float bufferDistance;
    
    public static bool isFacingRight = true;

    public static bool notPulling = false;
    
    public LayerMask platformMask;
    

    // Start is called before the first frame update
    void Start() {    
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        getMovementInputs();
        flip();
    }

    // Use FixedUpdate to deal with physics 
    void FixedUpdate() {
        myRigidBody.velocity = new Vector2(horizontal * walkingSpeed, myRigidBody.velocity.y);
        jump();
    }


    private void flip() {    
        if (notPulling) {
            if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0) {        
            isFacingRight = !isFacingRight;       
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;        
            transform.localScale = localScale;
            }
        }
    }

    private bool IsGrounded() {
        Bounds bounds = myBoxCollider.bounds;
        RaycastHit2D touchGround = Physics2D.Raycast(new Vector2(transform.position.x, bounds.min.y), Vector2.down, bufferDistance, platformMask);
        return touchGround;
    }

    private void jump() {
        if (Input.GetKey("space")) { 
            if (IsGrounded()) {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }   
        }
    }

    private void getMovementInputs() {
        // Input.GetAxisRaw("") returns -1/0/1;
        horizontal = Input.GetAxisRaw("Horizontal");
    }


    private void OnDrawGizmos() {
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector2(transform.position.x, bounds.min.y), bufferDistance * -transform.up);
    }

}
