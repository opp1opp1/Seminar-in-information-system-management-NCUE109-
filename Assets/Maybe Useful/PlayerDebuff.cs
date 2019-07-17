using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuff : MonoBehaviour {
    private float normalspeed;
    private float slowspeed;
    Color normalcolor;
    Color slowcolor = Color.blue;
    Color Freezecolor = new Vector4(0f, 0f, 1f, 0.5f);
    public float Slowtime = 0f;
    public float Freezetime = 0f;
    // Use this for initialization
    void Start () {
		slowspeed = gameObject.GetComponent<Playermove>().MoveSpeed*0.8f;
        normalspeed = gameObject.GetComponent<Playermove>().MoveSpeed;
        normalcolor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
       Slow();
        Freeze();

    }
    void Slow() {
        Slowtime -= Time.deltaTime;
        
        if (Slowtime > 0 )
        {
            gameObject.GetComponent<Playermove>().MoveSpeed = slowspeed;
            gameObject.GetComponent<MeshRenderer>().material.color = slowcolor;
        }
         if (Slowtime > 2.0f)
        {
            Slowtime = 2.0f;
        }
         if (Slowtime <= 0f)
        {
            Slowtime = 0f;
            gameObject.GetComponent<Playermove>().MoveSpeed=normalspeed ;
            gameObject.GetComponent<MeshRenderer>().material.color=normalcolor;
            
        }
    }
    void Freeze()
    {
        Freezetime -= Time.deltaTime;

        if (Freezetime > 0)
        {
            gameObject.GetComponent<Playermove>().MoveSpeed = 0f;
            gameObject.GetComponent<MeshRenderer>().material.color = Freezecolor;
        }
        if (Freezetime > 2.0f)
        {
            Freezetime = 2.0f;
        }
        if (Freezetime <= 0f)
        {
            Freezetime = 0f;
            gameObject.GetComponent<Playermove>().MoveSpeed = normalspeed;
            gameObject.GetComponent<MeshRenderer>().material.color = normalcolor;

        }
    }
}
