using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    public GameObject hammer;
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Target = new GameObject();
        leap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void leap()
    {

        rb.velocity = new Vector2(rb.velocity.x, 20);
        animator.SetTrigger("Leap");


    }

    void leapThrow()
    {


        Instantiate(hammer, transform.position, Quaternion.identity);
        
    }

    public void land(Vector2 target)
    {
        animator.SetTrigger("Land");
        float step = speed * Time.deltaTime;
        transform.position =  Vector2.MoveTowards(transform.position, target, step);

    }
}
