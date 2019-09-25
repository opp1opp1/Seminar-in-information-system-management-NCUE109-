using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldbar : MonoBehaviour {
    public float maxHP;
    public float currentHP;
   
    private float currentSheild;
    private GameObject target;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Ashe");
    }
	
	// Update is called once per frame
	void Update () {

        currentSheild = target.GetComponent<PlayerStats>().currentSheild;
        currentHP = target.GetComponent<PlayerStats>().currentHealth;
        
        if(currentSheild>0)
        {
            if ( currentHP == maxHP)
            {
                this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
            }
            else
            {
                this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP+currentSheild/100), 0.0f, 0.0f);
            }
        }
        else
        {
            this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
        }
            
            
        
  
        /*if (currentSheild > 0)
            {
                 this.transform.localPosition = target.GetComponent<Healthbar>().transform.position;
            }
        else
            {
                this.transform.localPosition = target.GetComponent<Healthbar>().transform.position;
        }
        //this.transform.localPosition = new Vector3(-105 + 105 * (c / 100), 0.0f, 0.0f); */
    }
}



