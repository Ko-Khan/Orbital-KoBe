using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBlock : MonoBehaviour
{
    private Rigidbody2D platform;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody2D>();
        platform.Sleep();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {

        Invoke("collapse", 3);
    }

    private void collapse() 
    {
        animator.SetTrigger("Off");
        platform.WakeUp();
    }
}
