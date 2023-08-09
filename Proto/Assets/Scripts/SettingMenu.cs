using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{

    public AudioSource music;

    public Slider musicSlider;

    public Slider sfxSlider;

    public AudioSource SFX;

    // public AudioMixer audioMixer;

   void Start()
   {
    music.volume = 0.2f;
   }

   public void SetVolumeMusic()
   { 
    //   audioMixer.SetFloat("volume", volume);
     music.volume = musicSlider.value;
   }

   public void SetVolumeSFX()
   {
     SFX.volume = sfxSlider.value;
   }
}
