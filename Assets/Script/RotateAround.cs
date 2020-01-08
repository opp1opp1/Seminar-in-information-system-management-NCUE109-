using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {


    private GameObject boss;
    public float speed;

    // Use this for initialization
    void Start () {
        boss = GameObject.Find("Enemy9");
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(boss.transform.position, new Vector3(0.0f, 1.0f, 0.0f), 100 * Time.deltaTime *speed);
	}
}
