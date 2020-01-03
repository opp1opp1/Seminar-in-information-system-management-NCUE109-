using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDontDestroyOnLoad : MonoBehaviour {
    private static MDontDestroyOnLoad instance = null;
    public static MDontDestroyOnLoad Instance
    {
        get { return instance; }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
