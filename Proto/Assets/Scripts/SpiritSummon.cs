using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSummon : MonoBehaviour
{

    public Summon[] summons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Summon()
    {
        foreach (Summon s in summons)
        {
            s.summon();
        }
    }
}
