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

    private int jumpNo;

   [SerializeField] private float inputDelay;

    private float t;

    public float terminalVelocity = 9.81f;
    
    public bool isFacingRight = true;

    public static bool notPulling = true;
    
    public LayerMask platformMask;

    public Animator animator;
    

    // Start is called before the first frame update
    void Start() {    
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        animator.SetBool("IsDead", false);
        animator.SetBool("OnGround", true);
        animator.SetBool("IsIdle", true);
        jumpNo = 1;
        t = 0;
    }

    void Update() {
        
        getMovementInputs();
        flip();
        
        
        if (IsGrounded()) {
            animator.SetBool("OnGround", true);
            jumpNo = 1 ;
            

            if (horizontal != 0f) {
                animator.SetBool("IsIdle", false);
            } else {
                animator.SetBool("IsIdle", true);
            }
        } else {
            animator.SetBool("IsIdle", true);
            animator.SetBool("OnGround", false);
        }
    }

    // Use FixedUpdate to deal with physics 
    void FixedUpdate() {
        myRigidBody.velocity = new Vector2(horizontal * walkingSpeed, myRigidBody.velocity.y);
        if (IsGrounded() )
        {
            jumpNo = 1;
            t = 0;
            
        }
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

    public bool IsGrounded() {
        Bounds bounds = myBoxCollider.bounds;
        RaycastHit2D touchGround = Physics2D.Raycast(new Vector2(transform.position.x, bounds.min.y), Vector2.down, bufferDistance, platformMask);
        return touchGround;
    }

    private void jump() {
        if (Input.GetKey(KeyCode.Space)) { 
            if (jumpNo > 0 && t <= 0) {
                jumpNo -= 1;
                Debug.Log("Jumped");
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                t = inputDelay;
            }

            t -= Time.deltaTime;
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

    public void DoubleJump() {
        jumpNo = 1;
    }

}
