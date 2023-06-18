using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost10s : MonoBehaviour
{

    public Animator animator;
    public float buffDuration = 10f;
    public float jumpForceMultiplier = 1.5f;

    private void Start() {
        animator.ResetTrigger("PickUp");
    }

    private void OnTriggerEnter2D(Collider2D player) {
       
       if (player.CompareTag("Player")) {
            
            StartCoroutine(Pickup(player));
        
        }

    }

    private IEnumerator Pickup(Collider2D player) {
        animator.SetTrigger("PickUp");

        PlayerMovement attributes = player.GetComponent<PlayerMovement>();
        
        attributes.jumpForce *= jumpForceMultiplier;

        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(1f);

        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(buffDuration);

        attributes.jumpForce /= jumpForceMultiplier;

        Destroy(gameObject);
    }
}
