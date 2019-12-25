using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicChecker : MonoBehaviour {
    AudioSource bmm;
	// Use this for initialization
	void Start () {
        bmm = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        if (bmm ==true)
        {
            //Destroy(GameObject.Find("Background Music"));
            bmm.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
