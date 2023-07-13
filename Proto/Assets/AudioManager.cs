using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------AudioSource----------")]
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource sfx;
    [Header("-------AudioClips-----------")]
    [SerializeField] private AudioClip background;
    


    // Start is called before the first frame update
    void Start()
    {
        bgm.clip = background;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
