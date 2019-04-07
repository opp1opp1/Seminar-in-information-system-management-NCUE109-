using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMountainMove : MonoBehaviour {
    public float IceMountain_Raise_speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.y<5) {
            transform.Translate(Vector3.up * Time.deltaTime * IceMountain_Raise_speed);
        }
        else
        {
            transform.Translate(Vector3.up* Time.deltaTime *0f);
        }
    }
}
