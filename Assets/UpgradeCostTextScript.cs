using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCostTextScript : MonoBehaviour {
    private GameObject target;
	// Use this for initialization
	void Start () {
        if (this.gameObject.name == "Hp Upgrade Text")
        {
            target = GameObject.Find("HPup");
        }
        if (this.gameObject.name == "ATK Upgrade Text")
        {
            target = GameObject.Find("ATKup");
        }
        if (this.gameObject.name == "ASPD Upgrade Text")
        {
            target = GameObject.Find("ASPDup");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "Hp Upgrade Text")
        {
            this.GetComponent<Text>().text = "" + target.GetComponent<UpgradeScript>().multiplevalue*20;
           

        }
        else if (this.gameObject.name == "ATK Upgrade Text")
        {
            this.GetComponent<Text>().text = "" + target.GetComponent<UpgradeScript>().multiplevalue * 50;
            

        }
        else if (this.gameObject.name == "ASPD Upgrade Text")
        {
            this.GetComponent<Text>().text = "" + target.GetComponent<UpgradeScript>().multiplevalue * 25;
            

        }
    }
}
