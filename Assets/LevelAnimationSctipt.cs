using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimationSctipt : MonoBehaviour {
    private GameObject target;
    private bool AnimationPlay = false;
    // Use this for initialization
    void Start () {
		target = GameObject.Find("Ashe");
    }
	
	// Update is called once per frame
	void Update () {
        if (target.GetComponent<PlayerRotation>().enemychecker == false)
        {
            AnimationPlay = true;
        }

    }
}
