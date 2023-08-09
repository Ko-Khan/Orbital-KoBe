using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperDash : MonoBehaviour
{

    [SerializeField] public Transform dashStart;

    [SerializeField] public Transform dashEnd;

    [SerializeField] private float speed;

    private Vector3 goBackTo;
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
        goBackTo = dashEnd.position;
        transform.position = dashStart.position;
    }

    public bool reachedEnd()
    {
        if (transform.position.x == goBackTo.x)
        {
            return true;
        }

        return false;
    }

    public void Dash()
    {
        transform.position = Vector2.MoveTowards(transform.position, goBackTo, Time.deltaTime * speed);
    }
}
