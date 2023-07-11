using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower_Flip : MonoBehaviour
{

    public bool isFacingRight;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight && rb.velocity.x < 0)
        {
            Flip();

        }

        if (!isFacingRight && rb.velocity.y > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        isFacingRight = !(isFacingRight);
    }
}
