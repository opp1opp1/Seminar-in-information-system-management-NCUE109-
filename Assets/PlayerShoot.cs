using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public  float Ultmatecharge;
    private GameObject target;
    // Use this for initialization
    void Start () {
         target = GameObject.Find("Ashe");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<Playermove>().Characterismoving == false)
        {
            //Instantiate()
        }

    }
    
}
