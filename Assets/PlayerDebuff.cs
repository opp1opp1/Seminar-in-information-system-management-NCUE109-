using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuff : MonoBehaviour {
    private float normalspeed;
    private float slowspeed;
    Color normalcolor;
    Color slowcolor = Color.blue;
    public float Slowtime = 0f;
    // Use this for initialization
    void Start () {
		slowspeed = gameObject.GetComponent<Playermove>().moveSpeed*0.8f;
        normalspeed = gameObject.GetComponent<Playermove>().moveSpeed;
        normalcolor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
       Slow();
        
	}
    void Slow() {
        Slowtime -= Time.deltaTime;
        
        if (Slowtime > 0 )
        {
            gameObject.GetComponent<Playermove>().moveSpeed = slowspeed;
            gameObject.GetComponent<MeshRenderer>().material.color = slowcolor;
        }
         if (Slowtime > 2.0f)
        {
            Slowtime = 2.0f;
        }
         if (Slowtime <= 0f)
        {
            Slowtime = 0f;
            gameObject.GetComponent<Playermove>().moveSpeed=normalspeed ;
            gameObject.GetComponent<MeshRenderer>().material.color=normalcolor;
            
        }
    }
}
