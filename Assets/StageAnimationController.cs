using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAnimationController : MonoBehaviour {
    private GameObject target;
    private bool isopened;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Ashe");
	}
	
	// Update is called once per frame
	void Update () {
        if (target.GetComponent<PlayerRotation>().enemychecker == true)
        {
            GetComponent<Animation>().Play("Idle");
        }
        else if (target.GetComponent<PlayerRotation>().enemychecker == false && isopened == false)
        {
            GetComponent<Animation>().Play("Open");
            isopened = true;
        }
        else
        {
            GetComponent<Animation>().Play("Opened");
        }
	}
}
