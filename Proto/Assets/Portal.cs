using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    

    private GameObject player;
    
    private Transform destination;
    
    [SerializeField] private float distance;

    [SerializeField] private GameObject Destination;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        destination = Destination.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(other.transform.position, transform.position) > distance)
        {
            GameObject.FindWithTag("Audio").GetComponent<AudioManager>().PlaySFX("Portal");
            player.transform.position = new Vector2(destination.position.x , destination.position.y);
        }
    }


  
}
