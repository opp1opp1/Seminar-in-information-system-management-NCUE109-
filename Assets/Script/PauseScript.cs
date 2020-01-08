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
        //Button btn = this.GetComponent<Button>();
        //btn.onClick.AddListener(OnClick);

        st = Resources.Load<Sprite>("stop");    //設定圖片，要設定的圖片要丟到Resource資料夾裡
        go = Resources.Load<Sprite>("play");
        im = this.GetComponent<Image>();
    }
    
    void Update()
    {
        if(isPaused == true)
        {
            im.sprite = go; //暫停時圖片變成play
        }
        else
        {
            im.sprite = st; //繼續時圖片變成stop
        }
    }
    
    public void pauseGame()
    {

        if (isPaused)
        {
            bgMusicAudioSource.UnPause();//繼續音樂

            Time.timeScale = 1; 
            isPaused = false;
            Instantiate(Showmusic, transform.position, transform.rotation);

        }
        else
        {
            bgMusicAudioSource.Pause(); //暫停音樂

            Time.timeScale = 0;
            isPaused = true;
            Instantiate(Showmusic, transform.position, transform.rotation);

        }
    }
    
}
