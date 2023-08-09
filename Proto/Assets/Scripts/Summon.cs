using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject minion;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void summon()
    {
        Instantiate(minion, transform.position, transform.rotation);
    }
}
