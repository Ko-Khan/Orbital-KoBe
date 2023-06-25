using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAction : MonoBehaviour
{
    public Transform grabbingZone;

    public Transform boxHolder; 

    public float rayDistance;

    private Vector2 directionalVector() {
        if (PlayerMovement.isFacingRight) {
            return Vector2.right;
        } else {
            return Vector2.left;
        }
    }


    void FixedUpdate() {
        
        // Raycast has parameters for (initial position, direction, distance)
        RaycastHit2D grabPredicate = Physics2D.Raycast(grabbingZone.position, directionalVector() * transform.localScale, rayDistance);
        
        // A box is detected in the grabDetection zone 
        if (grabPredicate.collider != null && grabPredicate.collider.tag == "Box") {
            
            // the "g" key is pressed to grab a Box
            if (Input.GetKey(KeyCode.G)) {

                grabPredicate.collider.gameObject.transform.parent = boxHolder;

                grabPredicate.collider.gameObject.transform.position = boxHolder.position;

                grabPredicate.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

                //GetComponent<Rigidbody2D>().isKinematic = true;

                //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

                PlayerMovement.notPulling = false;
            } else {

                grabPredicate.collider.gameObject.transform.parent = null;

                grabPredicate.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

                //GetComponent<Rigidbody2D>().isKinematic = false;

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                PlayerMovement.notPulling = true;
            }
        }
        
    }

}