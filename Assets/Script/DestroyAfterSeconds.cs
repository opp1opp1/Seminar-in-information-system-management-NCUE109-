using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {
    public float DestoryedTime= 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DestoryedTime -= Time.deltaTime;
        if (DestoryedTime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
