using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestroy : MonoBehaviour {
    private float lifeTime;
    public float maxTime = 3.0f;
    public float bullet_damage = 20.0f;
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

    //弓箭射到物體時消失
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
