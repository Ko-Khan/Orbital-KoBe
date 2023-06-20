using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    public GameObject waypoint1;
    public GameObject waypoint2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void flip() {    
            if (transform == waypoint1.transform || transform == waypoint2.transform) {           
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;        
            transform.localScale = localScale;
            }
        }
    
}
