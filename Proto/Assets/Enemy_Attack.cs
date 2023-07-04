using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("yarr");
      Attack();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
