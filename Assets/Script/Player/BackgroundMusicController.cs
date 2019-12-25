using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour {
    AudioSource bm;
	// Use this for initialization
	void Start () {
        bm = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        bm.enabled = true;
        /*foreach (var dontobj in Background Music)
        {
            GameObject.Find("Background Music").SetActive(true);
        }*/

    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
