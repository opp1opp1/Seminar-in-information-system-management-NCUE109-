using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour {
    public float Bullet_Fly_speed;
   
    // Use this for initialization
    void Start () {
        if (this.gameObject.name == "Sword(Clone)")
        {
            Bullet_Fly_speed = 5f;

        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * Bullet_Fly_speed);
    }
}
