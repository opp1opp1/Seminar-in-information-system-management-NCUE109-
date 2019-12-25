using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgoundMusicControl : MonoBehaviour {
    AudioSource background;
    AudioSource main;
    static BackgoundMusicControl instanceB;

void Awake()
    {
        if(instanceB == null)
        {
            instanceB = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instanceB)
        {
            
            Destroy(gameObject);

        }
    }
    void Start () {
        background = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        main = GameObject.FindGameObjectWithTag("Main Music").GetComponent<AudioSource>();
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
    }

    private void OnClick()
    {
        background.mute = !background.mute;
        main.mute = !main.mute;
    }
}
