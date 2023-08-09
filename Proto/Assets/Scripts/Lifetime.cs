using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

    [SerializeField] private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    
}
