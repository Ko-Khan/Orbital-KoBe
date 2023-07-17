using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArm : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Player;

    public float speed;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == Player.GetComponent<Collider2D>())
        {
            Player.GetComponent<Health>().TakeDamage(10);
            Destroy(gameObject);
        }


    }
}
