using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private GameObject Player;
    private GameObject Target;
    private Animator animator;
    void Start()
    {
        Target = new GameObject();
        Player = GameObject.FindWithTag("Player");
        Target.transform.position = Player.GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Target.transform.position)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, step);
        }

        if (transform.position.y <= -4.4)
        {
            Destroy(GetComponent<Rigidbody2D>());
            animator.SetTrigger("Boom");
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other == Player.GetComponent<Collider2D>())
       {
        Player.GetComponent<Health>().TakeDamage(8);

       } 
    }
}
