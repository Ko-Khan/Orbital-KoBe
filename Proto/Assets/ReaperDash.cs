using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperDash : MonoBehaviour
{

    [SerializeField] private Transform dashStart;

    [SerializeField] private Transform dashEnd;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        transform.position = dashStart.position;
    }

    public bool reachedEnd()
    {
        if (transform.position.x >= dashEnd.position.x)
        {
            return true;

        }

        return false;
    }

    public void Dash()
    {
        transform.position = Vector2.MoveTowards(transform.position, dashEnd.position, Time.deltaTime * speed);
    }
}
