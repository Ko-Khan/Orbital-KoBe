using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D rb;
    public Animator anim;
    public Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform) {
            rb.velocity = new Vector2(speed, 0);
        } else {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
