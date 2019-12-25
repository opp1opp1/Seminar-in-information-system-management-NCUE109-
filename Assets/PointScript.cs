using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointScript : MonoBehaviour {
    public int point;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            PlayerPrefs.SetFloat("Money",++point);
            Debug.Log(PlayerPrefs.GetFloat("Money"));
            point = 0;
            Destroy(this.gameObject);
        }
    }
}
