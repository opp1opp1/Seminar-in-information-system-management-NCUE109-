using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicChecker : MonoBehaviour {
    AudioSource bmm;
    AudioSource mmm;
    

    /*private static BackgroundMusicChecker instance = null;
    public static BackgroundMusicChecker Instance
    {
        get { return instance; }
    }*/

    // Use this for initialization
    void Awake () {
        
        /*
         * if (mmm.enabled == true)
        {
            bmm.enabled = false;
        }
        */

        /*
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        */
    }
	
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update () {
        bmm = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        mmm = GameObject.FindGameObjectWithTag("Main Music").GetComponent<AudioSource>();
        

        if (SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "SetScene"
            || SceneManager.GetActiveScene().name == "BoxScene")
        {
            mmm.enabled = true;
        }
        else
        {
            mmm.enabled = false;
        }

        if (mmm.enabled == true)    //當main music開著時，關掉background music
        {
            bmm.enabled = false;
        }

        
    }
}
