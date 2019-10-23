using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
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

        maxHP = PlayerIni.basicHealth;
        currentHP = PlayerIni.basicHealth;
        currentSheild = PlayerIni.currentSheild;


        if (currentSheild > 0)
        {
            if (currentHP == maxHP)
            {
                //this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP - currentSheild / 100), 0.0f, 0.0f);
                GetComponent<Image>().fillAmount = currentHP / (maxHP- currentSheild);
            }

            else
            {
                //this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
                GetComponent<Image>().fillAmount = currentHP / maxHP;
            }
        }
        else
        {
            //this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
            GetComponent<Image>().fillAmount = currentHP / maxHP;
        }
	}
}


