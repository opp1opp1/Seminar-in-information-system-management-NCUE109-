using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSFXItself : MonoBehaviour {
    public GameObject sf;
    AudioSource sfa;

	// Use this for initialization
	void Start () {
        sf = GameObject.FindGameObjectWithTag("Main Music");
        sfa = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sf)
        {
            if (sf.GetComponent<SFXChecker>().sfx == false)
                sfa.mute = true;
            else
                sfa.mute = false;
        }
    }
}
