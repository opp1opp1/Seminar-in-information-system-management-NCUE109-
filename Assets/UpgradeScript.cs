using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UpgradeScript : MonoBehaviour {
    public int multiplevalue;
    private float value;
    // Use this for initialization
    void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "HPup")
        {
            multiplevalue = (int)((PlayerPrefs.GetFloat("Health") - 100) / 25);
            if (multiplevalue == 0)
            {
                multiplevalue = 1;
            }
        }
        else if (this.gameObject.name == "ATKup")
        {
            multiplevalue = (int)((PlayerPrefs.GetFloat("Attack") - 20) / 5);
            if (multiplevalue == 0)
            {
                multiplevalue = 1;
            }
        }
        else if (this.gameObject.name == "ASPDup")
        {
            multiplevalue = (int)((PlayerPrefs.GetFloat("AttackSpeed") - 1) / 0.015);
            if (multiplevalue == 0)
            {
                multiplevalue = 1;
            }
        }
    }
    public void OnClick()   
    {
        if (this.gameObject.name == "HPup")
        {
            if (PlayerPrefs.GetFloat("Money") >= multiplevalue * 20)
            {
                value = PlayerPrefs.GetFloat("Money");
                Debug.Log(value);
                value -= multiplevalue * 20;
                Debug.Log(value);
                PlayerPrefs.SetFloat("Money", value);
                value = PlayerPrefs.GetFloat("Health");
                Debug.Log(value);
                value += 25;
                Debug.Log(value);
                PlayerPrefs.SetFloat("Health", value);
            }

        }
        else if (this.gameObject.name == "ATKup")
        {
            if (PlayerPrefs.GetFloat("Money") >= multiplevalue * 50)
            {
                value = PlayerPrefs.GetFloat("Money");
                Debug.Log(value);
                value -= multiplevalue * 25;
                Debug.Log(value);
                PlayerPrefs.SetFloat("Money", value);
                value = PlayerPrefs.GetFloat("Attack");
                Debug.Log(value);
                value += 5;
                Debug.Log(value);
                PlayerPrefs.SetFloat("Attack", value);
            }
        }
        else if (this.gameObject.name == "ASPDup")
        {
            if (PlayerPrefs.GetFloat("Money") >= multiplevalue * 25)
            {
                value = PlayerPrefs.GetFloat("Money");
                Debug.Log(value);
                value -= multiplevalue * 25;
                Debug.Log(value);
                PlayerPrefs.SetFloat("Money", value);
                value = PlayerPrefs.GetFloat("AttackSpeed");
                Debug.Log(value);
                value += 0.015f;
                Debug.Log(value);
                PlayerPrefs.SetFloat("AttackSpeed", value);
            }
        }
    }
    }
