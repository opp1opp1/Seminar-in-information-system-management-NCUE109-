using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUIAppear : MonoBehaviour {
    
    GameObject gameFPanel;
	// Use this for initialization
	void Start () {
        gameFPanel = GameObject.Find("FPanel");
        gameFPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "powerup(Clone)")
        {
            
            gameFPanel.gameObject.SetActive(true);
            Debug.Log("hi");
        }
    }
}
