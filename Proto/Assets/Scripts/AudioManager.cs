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
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip walk;
    [SerializeField] private AudioClip portal;
    


    // Start is called before the first frame update
    void Start()
    {
        bgm.clip = background;
        bgm.Play();
    }

   public void PlaySFX(string track)
    {
        switch(track)
        {
            case "Attack":
            sfx.clip = attack;
            sfx.Play();
            break;

            case "Walk":
            sfx.clip = walk;
            sfx.Play();
            break;

            case "Portal":
            sfx.clip = portal;
            sfx.Play();
            break;

            default:
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
