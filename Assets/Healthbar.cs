using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {
    public float maxHP;
    public float currentHP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentHP = EnemyBehavior.targethealth;
        this.transform.localPosition = new Vector3(-105+105*(currentHP/maxHP), 0.0f, 0.0f);
	}
}
