using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Invoke("collapse", 3);
    }

    private void collapse() 
    {
        //GetComponent<Collider2D>.enabled = false;
        //GetComponent<SpriteRenderer>.enabled = false;
        Destroy(gameObject);
    }
}
