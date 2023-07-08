using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Enemy : MonoBehaviour
{


      [SerializeField] private float speed;
      [SerializeField] private float range;
      [SerializeField] private float size;
      [SerializeField] private Transform Player;
      [SerializeField] private float minimumDistance;
      [SerializeField] private LayerMask playerLayer;
      [SerializeField]private BoxCollider2D boxCollider;
       [SerializeField] private Transform home;
      private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsIdle", true);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSight())
        {
            animator.SetBool("IsIdle", false);
            Follow();
        } else if (home.position.x != transform.position.x) {
            Debug.Log("???");
            transform.position = Vector2.MoveTowards(transform.position, home.position, speed * Time.deltaTime);
        } else {
        animator.SetBool("IsIdle", true);
        }

    }

    void Follow() 
    {
        if (Vector2.Distance(transform.position, Player.position) > minimumDistance) {
            
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

    }

    bool PlayerInSight() 
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x,
     boxCollider.bounds.size, 0, Vector2.left,
        0, playerLayer);
        return hit.collider != null;

    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x,
        new Vector3(boxCollider.bounds.size.x * size, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
