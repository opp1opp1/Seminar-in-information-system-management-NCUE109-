using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrowScript : MonoBehaviour {
    private int direction = 1;
    public float changetime = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        changetime -= Time.unscaledDeltaTime;
        transform.Translate(0, 2*direction, 0);

        if (changetime <= 0f)
        {
            direction = direction * -1;
            changetime = 1f;
        }
    }
}
