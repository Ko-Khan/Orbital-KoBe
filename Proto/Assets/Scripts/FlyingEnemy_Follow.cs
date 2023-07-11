using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy_Follow : MonoBehaviour
{

    [SerializeField] private Transform home;
    [SerializeField] private float speed;
    [SerializeField] private float size;
    [SerializeField] private LayerMask playerLayer;
     private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
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
       transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
     }

     bool PlayerInSight() 
     {
       Collider2D hit = Physics2D.OverlapCircle(transform.position, size, playerLayer);

       if (hit == null) {
        return false;
       }
       return true;
     }

     void OnDrawGizmos()
     {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
     }
}
