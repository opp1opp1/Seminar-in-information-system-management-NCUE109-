using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXChecker : MonoBehaviour {
    //public AudioSource sfxm;
    public bool sfx = true;    //用來檢測sfx的開關

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //sfxm = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();

        /*
        if (sfx == false)
        {
            sfxm.mute = true;
        }
        else
        {
            sfxm.mute = false;
        }
        */
    }
}
