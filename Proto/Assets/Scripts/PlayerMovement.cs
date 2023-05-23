using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private BoxCollider2D myBoxCollider;
    private float horizontal;
    public float speed;
    public float jumpForce;
    public float maxDistance;
    public bool isFacingRight = true;
    public LayerMask layerMask;
    
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

        if (Input.GetKeyDown("space") && Physics2D.Raycast(transform.position, -transform.up, maxDistance, layerMask).collider) {
       myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }


    }


    void FixedUpdate() 
    {
       
        myRigidBody.velocity = new Vector2(horizontal * speed, myRigidBody.velocity.y);
        
}

   private void flip() {
    if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0) {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

    }
   }

   private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawRay(transform.position, - (maxDistance * transform.up));
   }

   
}
