using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestroy : MonoBehaviour {
    private float lifeTime;
    public float maxTime = 3.0f;
    // Use this for initialization
    void Start () {
        lifeTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
