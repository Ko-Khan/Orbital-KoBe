using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    
    private Vector3 pos;

    // Start is called before the first frame update
    void Start() {
        GameObject Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;
    }
}
