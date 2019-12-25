using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoryedOnLoad : MonoBehaviour {
    private static DontDestoryedOnLoad instance = null;
    public static DontDestoryedOnLoad Instance {
        get { return instance; }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "MainScene" || SceneManager.GetActiveScene().name != "SetScene" 
            || SceneManager.GetActiveScene().name != "BoxScene")
        {
            GameObject.Find("Background Music").SetActive(true);
        }
	}
    
    
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // any other methods you need

}
