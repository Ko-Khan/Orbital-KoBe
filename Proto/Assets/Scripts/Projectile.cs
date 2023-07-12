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

    [SerializeField] private float direction;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 localScale = transform.localScale;
        localScale *= -1f * direction;
        lifeSpan = Time.time + lifeSpan;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lifeSpan) 
        {
            Destroy(gameObject);
        }
        Move(direction);
    }

    void Move(float direction) 
    {

       rb.velocity =  Vector2.right * (direction) * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            DamagePlayer();
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Platform")) {
            Destroy(gameObject);
        }
    }

    void DamagePlayer()
    {
        Player.GetComponent<Health>().TakeDamage(damage);
        

    }

    public void setDirection(float direction) 
    {
        this.direction = direction;

    }
}
