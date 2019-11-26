using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGenerator : MonoBehaviour {
    private float attackfixtime = 1.5f;
    private GameObject target;
    private GameObject Enemy6;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        attackfixtime -= Time.deltaTime;
        if (attackfixtime >= 0)
        {
            //target = GameObject.Find("Ashe");
            //transform.LookAt(target.transform.position);
            
            
        }
        else
        {
            
            Destroy(this.gameObject);
        }
	}
}
