using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private GameObject Player;

    private Rigidbody2D rb;

    [SerializeField] private float lifeSpan;

    [SerializeField] private int damage;

    [SerializeField] private float speed;

    [SerializeField] private int direction;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 localScale = transform.localScale;
        localScale *= -1f * direction;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move(direction);
    }

    void Move(int direction) 
    {

       rb.velocity =  Vector2.right * (direction) * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        DamagePlayer();
        Destroy(gameObject);
    }

    void DamagePlayer()
    {
        Player.GetComponent<Health>().TakeDamage(damage);
        

    }
}
