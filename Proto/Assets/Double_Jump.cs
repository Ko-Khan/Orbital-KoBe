using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Jump : MonoBehaviour
{

     private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void OnTriggerEnter2D(Collider2D player) 
    {
        
        if (player.CompareTag("Player")) 
        {
            
            player.GetComponent<PlayerMovement>().DoubleJump();
        }

        animator.SetTrigger("Eat");
    }

    void selfDestruct() 
    {
        Destroy(gameObject);
    }
}
