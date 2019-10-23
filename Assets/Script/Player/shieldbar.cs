using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        maxHP = PlayerIni.basicHealth;
        currentHP = PlayerIni.currentHealth;
        currentSheild = PlayerIni.currentSheild;

        // currentSheild = target.GetComponent<PlayerStats>().currentSheild;
        //currentHP = target.GetComponent<PlayerStats>().currentHealth;

        if (currentSheild>0)
        {
            if ( currentHP == maxHP)
            {
                // this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
                GetComponent<Image>().fillAmount = currentHP / (maxHP - currentSheild);
            }
            else
            {
                // this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP+currentSheild/100), 0.0f, 0.0f);
                GetComponent<Image>().fillAmount = currentHP / maxHP;
            }
        }
        else
        {
            //this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
            GetComponent<Image>().fillAmount = currentHP / maxHP;
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



