using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilty : MonoBehaviour
{

    private Transform Player;
    public float minDistance;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(Player.position, transform.position);
        if (Distance > minDistance) 
        {
            GetComponent<SpriteRenderer>().enabled = false;
        } else 
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
