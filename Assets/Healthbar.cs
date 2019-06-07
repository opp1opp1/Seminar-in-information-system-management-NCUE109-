using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {
    public float maxHP;
    public float currentHP;
    private GameObject target;
    // Use this for initialization
    void Start () {
		target = GameObject.Find("Ashe");
    }
	
	// Update is called once per frame
	void Update () {
        
        currentHP = target.GetComponent<PlayerStats>().currentHealth;
        this.transform.localPosition = new Vector3(-105+105*(currentHP/maxHP), 0.0f, 0.0f);
	}
}
