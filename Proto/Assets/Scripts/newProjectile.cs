using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float up;

    [SerializeField] private float right;

    [SerializeField] private float speed;

    [SerializeField] private float lifeTime;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
        new Vector2(transform.position.x + right, transform.position.y + up), speed * Time.deltaTime);
    }
}
