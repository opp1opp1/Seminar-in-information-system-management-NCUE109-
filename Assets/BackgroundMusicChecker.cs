using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (mmm.enabled == true)
        {
            bmm.enabled = false;
        }
    }
}
