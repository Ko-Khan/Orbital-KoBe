using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public LayerMask terrain;
    private Collider2D collider;
    private GameObject Player;
    private GameObject Target;
    private Animator animator;
    private Vector3 direction;
    void Start()
    {
        Target = new GameObject();
        Player = GameObject.FindWithTag("Player");
        Target.transform.position = Player.GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

        direction =  (Player.transform.position - transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (collider.IsTouchingLayers(terrain)) 
        {
            Debug.Log("Bam");
            Destroy(gameObject);
        } */
        transform.Translate(direction * Time.deltaTime * speed);

       

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other == Player.GetComponent<Collider2D>())
       {
        Player.GetComponent<Health>().TakeDamage(8);

       }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
        Destroy(gameObject);
        }
    }
}
