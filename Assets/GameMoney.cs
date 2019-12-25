using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMoney : MonoBehaviour {
    private GameObject target;
    private GameObject point;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Ashe");
        point = GameObject.Find("Point Counter");
        this.GetComponent<Text>().text = "" + 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (target.GetComponent<PlayerRotation>().enemychecker == false)
        {
            this.GetComponent<Text>().text = "" + point.GetComponent<PointScript>().point;
        }
	}
}
