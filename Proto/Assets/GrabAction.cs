using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAction : MonoBehaviour
{
    public Transform grabbingZone;

    public Transform boxHolder; 

    public float rayDistance;


    void Update() {
        
        // Raycast has parameters for (initial position, direction, distance)
        RaycastHit2D grabPredicate = Physics2D.Raycast(grabbingZone.position, Vector2.right * transform.localScale, rayDistance);
        
        // A box is detected in the grabDetection zone 
        if (grabPredicate.collider != null && grabPredicate.collider.tag == "Box") {
            
            // the "g" key is pressed to grab a Box
            if (Input.GetKey(KeyCode.G)) {

                grabPredicate.collider.gameObject.transform.parent = boxHolder;

                grabPredicate.collider.gameObject.transform.position = boxHolder.position;

                grabPredicate.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
         
            } else {

                grabPredicate.collider.gameObject.transform.parent = null;

                grabPredicate.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }
        
    }

}