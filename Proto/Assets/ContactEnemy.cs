using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    [SerializeField] private int Damage;
    [SerializeField] private float Force;
    

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other == Player.GetComponent<Collider2D>())
        {
        Player.GetComponent<Health>().TakeDamage(Damage);
        Player.GetComponent<Health>().Knockback(Force, 2, transform);
        }

    }
}
