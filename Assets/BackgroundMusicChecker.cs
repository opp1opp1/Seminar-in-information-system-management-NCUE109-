using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicChecker : MonoBehaviour {
    AudioSource bmm;
    AudioSource mmm;
	// Use this for initialization
	void Awake () {
        bmm = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        mmm = GameObject.FindGameObjectWithTag("Main Music").GetComponent<AudioSource>();
        if (mmm.enabled == true)
        {
            bmm.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "SetScene"
            || SceneManager.GetActiveScene().name == "BoxScene")
        {
            mmm.enabled = true;
        }
        else
        {
            mmm.enabled = false;
        }

        if (mmm.enabled == true)
        {
            bmm.enabled = false;
        }
        
    }
}
