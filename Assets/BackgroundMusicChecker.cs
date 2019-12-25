using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Background Music") ==true)
        {
            //Destroy(GameObject.Find("Background Music"));
            GameObject.Find("Background Music").SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
