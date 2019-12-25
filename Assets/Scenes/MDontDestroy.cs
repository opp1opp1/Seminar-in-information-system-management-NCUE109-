using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDontDestroy : MonoBehaviour {
    private static MDontDestroy instance = null;
    public static MDontDestroy Instance
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
