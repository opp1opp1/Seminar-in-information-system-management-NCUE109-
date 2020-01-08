using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
   
    bool isPaused = false;
    public GameObject Showmusic;
    private AudioSource bgMusicAudioSource;

    private Sprite st, go;
    private Image im;

    private void Awake()
    {
        //在所有Game Object中找尋Background Music
        bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
    }

    void Start()
    {
        st = Resources.Load<Sprite>("stop");    //設定圖片，要設定的圖片要丟到Resource資料夾裡
        go = Resources.Load<Sprite>("play");
        im = this.GetComponent<Image>();
    }

    public void pauseGame()
    {

        if (isPaused)
        {
            bgMusicAudioSource.Pause(); //繼續音樂
          
            Time.timeScale = 0; 
            isPaused = false;
            Instantiate(Showmusic, transform.position, transform.rotation);

            im.sprite = st; //繼續時圖片變成stop
        }
        else
        {
            bgMusicAudioSource.UnPause();//暫停音樂

            Time.timeScale = 1;
            isPaused = true;
            Instantiate(Showmusic, transform.position, transform.rotation);

            im.sprite = go; //暫停時圖片變成play
        }
    }

}
