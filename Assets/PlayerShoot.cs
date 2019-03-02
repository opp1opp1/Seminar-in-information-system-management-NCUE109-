using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject sphere;
    public float Shoot_Pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(sphere, (this.gameObject.transform.position + new Vector3( Shoot_Pos,0f, 0f)), this.gameObject.transform.rotation);
            sphere.gameObject.transform.rotation = this.gameObject.transform.rotation;
        } 

	}
}
