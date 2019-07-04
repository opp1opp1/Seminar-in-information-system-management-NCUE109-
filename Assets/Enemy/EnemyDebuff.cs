using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDebuff : MonoBehaviour {
    public bool slow;
    public float slowtime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (slow == true)
        {
            
            slowtime -= Time.deltaTime;
        }
	}
}
