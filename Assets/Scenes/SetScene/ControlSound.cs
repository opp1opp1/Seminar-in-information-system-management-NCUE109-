using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlSound : MonoBehaviour {
    AudioSource background;
    private static ControlSound instance = null;
    public static ControlSound Instance {   //讓此panel不會消失
        get { return instance; }
    }
	// Use this for initialization
	void Start () {
        background = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "SetScene")   //讓這個音效介面跟著不同的介面持續著，當在SetScene時顯示此panel
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().interactable = true;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else  //當離開SetScene時隱藏此Panel
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().interactable = false;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        if (SceneManager.GetActiveScene().name == "SetScene" || SceneManager.GetActiveScene().name == "MainScene" ||
            SceneManager.GetActiveScene().name == "CharacterScene" || SceneManager.GetActiveScene().name == "BoxScene")
        {   //當不在戰鬥畫面時，將戰鬥音樂mute
            background.mute = true;
        }
    }
    
    
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // any other methods you need
}
