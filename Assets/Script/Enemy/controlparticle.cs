using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlparticle : MonoBehaviour {

    public Transform emission;


	// Use this for initialization
	void Start () {
        //emission.GetComponent<ParticleSystem>().enableEmission = false;
    }
	
	// Update is called once per frame
	void OnTriggerEnter() {

        //emission.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stop_emission());

    }


    IEnumerator stop_emission()
    {
        yield return new WaitForSeconds(.4f);
        emission.GetComponent<ParticleSystem>().enableEmission = false;
    }
}

