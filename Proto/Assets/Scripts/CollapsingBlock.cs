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
        GameObject player = collision.collider.gameObject;
        if (player.GetComponent<PlayerMovement>().IsGrounded()) {
            Invoke("collapse", 0.1f);
        }
    }

    private void collapse() 
    {
        animator.SetTrigger("Off");
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<BoxCollider2D>().enabled = false;
        platform.WakeUp();
    }
}
