using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator.ResetTrigger("Attack");
    }


    void Update() {
        performAttack();
    }

    private void performAttack() {
        if (Input.GetKeyDown("f")) { 
            animator.SetTrigger("Attack");
        }
    }


}
