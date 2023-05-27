using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;
   private int currentWaypoint = 0;
   [SerializeField] private float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f) {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length) {
                currentWaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
