using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public bool Paused;

    public AudioMixer mixer;

    public GameObject pauseMenuUI;

     public AudioSource music;

    public Slider musicSlider;

    public Slider sfxSlider;

    public AudioSource SFX;


    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Paused)
            {
                Resume();
            } else {
                Pause();
            }

        }
    }

    void Pause() 
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        Paused = true;

        

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1.0f;

        Paused = false;
    }

    public void loadMenu()
    {
    Debug.Log("Menu!");
    }

    public void Quit()
    {
        
    }

     public void SetVolumeMusic()
   { 
    //   audioMixer.SetFloat("volume", volume);
    mixer.SetFloat("MusicVolume", musicSlider.value);
    PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
   }

   public void SetVolumeSFX()
   {
    mixer.SetFloat("SFXVolume", sfxSlider.value);
    PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
   }

// This is used at at the start of each scene, it chould set the valuenof each slider to the player's preference
   void SetSliders()
   {

    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

   }


}
