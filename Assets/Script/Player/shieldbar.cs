﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldbar : MonoBehaviour {
    public float maxHP;
    public float currentHP;
    public float maxSheild;
   
    private float currentSheild;
    private GameObject target;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Ashe");
    }
	
	// Update is called once per frame
	void Update () {
       // maxHP = PlayerIni.basicHealth;
       // currentHP = PlayerIni.currentHealth;
        //currentSheild =GetComponent<PlayerStats>().currentSheild;
        currentSheild =PlayerIni.currentSheild;
        //maxSheild = GetComponent<PlayerStats>().basicSheild;
        maxSheild = PlayerIni.basicSheild;


        GetComponent<Image>().fillAmount = (currentSheild / maxSheild);
       /* if (currentSheild>0)
        {
            GetComponent<Image>().fillAmount = (currentSheild / maxSheild);
        }
        else
        {
            GetComponent<Image>().fillAmount = (currentSheild / maxSheild);
        }

        */
            
    }
}



