using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool reached = false;

    public Animator animator;

    // Start is called before the first frame update
    private void Start() {
        animator.SetBool("CheckpointReached", false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !reached) {
            reached = true;
            animator.SetBool("CheckpointReached", true);
            //other.gameObject.GetComponent<Respawn>().updateRespawnPoint(this.transform.position);
            other.gameObject.GetComponent<Player>().SavePlayerInfo();
        }
    }
}
