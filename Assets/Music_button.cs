using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_button : MonoBehaviour {

    private AudioSource bgMusicAudioSource;
    bool isON = true;
    private void Awake()
    {
        //在所有Game Object中找尋Background Music
        bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
    }
    public void musicbutton()
    {

        if (isON)
        {

            //暫停音樂
            bgMusicAudioSource.Stop();
            Time.timeScale = 0;
            isON = false;

        }
        else
        {

            //繼續音樂
            bgMusicAudioSource.Play();

            Time.timeScale = 1;
            isON = true;
        }
    }
}
