using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public bool isFacingRight;
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    void Flip() 
    {
        
        if (isFacingRight && Player.position.x < transform.position.x || !isFacingRight && Player.position.x > transform.position.x)
        {
            isFacingRight = !(isFacingRight);
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;        
            transform.localScale = localScale;


        }
    }
}