using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Enemy : MonoBehaviour
{


      [SerializeField] private float speed;
      [SerializeField] private float range;
      [SerializeField] private Transform Player;
      [SerializeField] private float minimumDistance;
      [SerializeField] private LayerMask playerLayer;
      private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSight())
        {
            Follow();
        }
    }

    void Follow() 
    {
        if (Vector2.Distance(transform.position, Player.position) > minimumDistance) {
            animator.SetBool("IsIdle", false);
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

    }

    bool PlayerInSight() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, range, playerLayer);
        return hit.collider != null;

    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.right * range);
    }
}
