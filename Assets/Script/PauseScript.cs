using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
   
    bool isPaused = false;
    public GameObject Showmusic;
    private AudioSource bgMusicAudioSource;

    private void Awake()
    {
        //在所有Game Object中找尋Background Music
        bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
    }
    public void pauseGame()
    {

        if (isPaused)
        {   
            //繼續音樂
            bgMusicAudioSource.UnPause();
          
            Time.timeScale = 1;
            isPaused = false;
            Instantiate(Showmusic, transform.position, transform.rotation);



        }
        else
        {
            //暫停音樂
            bgMusicAudioSource.Pause();
            Time.timeScale = 0;
            isPaused = true;
            Instantiate(Showmusic, transform.position, transform.rotation);

        }
    }

}
