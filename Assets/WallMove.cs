using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour {
    private int direction =1;
    public float changetime = 1f;
    public GameObject ash;
    // Use this for initialization
    void Start () {
        ash = GameObject.Find("Ashe");
	}
	
	// Update is called once per frame
	void Update () {
        if (!ash.GetComponent<FUIAppear>().isPaused)
        {
            changetime -= Time.deltaTime;
            transform.Translate(0, 0, 0.1f * direction);

            if (changetime <= 0f)
            {
                direction = direction * -1;
                changetime = 1f;
            }
        }
    }
    
       
}
