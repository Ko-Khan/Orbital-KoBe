using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Jump : MonoBehaviour
{

     private Animator animator;
     private float animTime = 1f;
     private bool eaten;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        eaten = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (animTime <= 0)
        {
            Destroy(gameObject);
        }
         if (eaten) 
         {
        animTime -= Time.deltaTime;
         }
    }
    void OnTriggerEnter2D(Collider2D player) 
    {
        
        if (player.CompareTag("Player")) 
        {
            
            player.GetComponent<PlayerMovement>().DoubleJump();
        }

        eaten = true;
    }
}
