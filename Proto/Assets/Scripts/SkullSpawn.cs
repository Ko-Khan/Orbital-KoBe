using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    private float waitTime;

    [SerializeField] private float Cooldown;

    [SerializeField] private GameObject Skull;
    void Start()
    {
        waitTime = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + Cooldown;
            Instantiate(Skull, transform.position, transform.rotation);
        }
    }
}
