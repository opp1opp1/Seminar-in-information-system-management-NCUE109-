using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行

public class HpScript : MonoBehaviour {
    public GameObject Ashe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "" + Ashe.GetComponent<PlayerStats>().currentHealth;
    }
}
