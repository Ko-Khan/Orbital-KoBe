using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyPlatform : MonoBehaviour
{

    private WayPointFollower follower;
    // Start is called before the first frame update
    void Start()
    {
        follower = GetComponent<WayPointFollower>();
        follower.enabled = false;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D player)
    {
        follower.enabled = true;


    }
}
