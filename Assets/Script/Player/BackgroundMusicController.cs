using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour {
    AudioSource bm;
    AudioSource mm;
	// Use this for initialization
    void Awake()
    {
        
        bm = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        bm.enabled = true;
    }
	void Start () {
        mm = GameObject.FindGameObjectWithTag("Main Music").GetComponent<AudioSource>();
        mm.enabled = false;
        /*foreach (var dontobj in Background Music)
        {
            GameObject.Find("Background Music").SetActive(true);
        }*/

    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
