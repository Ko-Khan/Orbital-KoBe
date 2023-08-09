using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    

    private GameObject player;
    
    private Transform destination;

    public float waitTime;
    
    [SerializeField] private float distance;

    [SerializeField] private GameObject Destination;

    [SerializeField] private float Cooldown;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        destination = Destination.transform;

        waitTime = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(other.transform.position, transform.position) > distance && Time.time > waitTime)
        {
            Destination.GetComponent<Portal>().waitTime = Time.time + Cooldown;
            GameObject.FindWithTag("Audio").GetComponent<AudioManager>().PlaySFX("Portal");
            player.transform.position = new Vector2(destination.position.x , destination.position.y);
        }
    }


  
}
