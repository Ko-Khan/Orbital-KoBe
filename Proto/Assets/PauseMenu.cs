using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public bool Paused;

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
     music.volume = musicSlider.value;
   }

   public void SetVolumeSFX()
   {
     SFX.volume = sfxSlider.value;
   }


}
