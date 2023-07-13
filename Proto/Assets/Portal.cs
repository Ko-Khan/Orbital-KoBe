using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    [SerializeField] private GameObject portal;
    private float waitingTime;
    private float downTime;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        waitingTime = 1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other = player.GetComponent<Collider2D>())
        {
            downTime = Time.time + waitingTime;
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            if (Time.time > downTime)
            {
              player.GetComponent<Transform>().position = portal.GetComponent<Transform>().position;
            }
        }

    }
}
