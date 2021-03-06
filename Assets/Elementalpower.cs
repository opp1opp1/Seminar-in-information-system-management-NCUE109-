﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elementalpower : MonoBehaviour {
    public GameObject gameFPanel;
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        gameFPanel = GameObject.Find("FPanel");
        
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()   //出現按鈕 點及按鈕 產生按鈕效果 把按鈕物件變成null
    {
        if (GameObject.Find("TutorialMask") == true)
        {
            GameObject.Find("TutorialMask").SetActive(false);
        }
        if (this.gameObject.name == "earth(Clone)")
        {
            PlayerIni.EarthArrow = true;
            Debug.Log("Yes! Earth is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[3] = null; 
        }
        else if (this.gameObject.name == "fire(Clone)")
        {
            PlayerIni.FireArrow = true;
            Debug.Log("Yes! Fire is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[4] = null;

        }
        else if (this.gameObject.name == "ice(Clone)")
        {
            PlayerIni.IceArrow = true;
            Debug.Log("Yes! Ice is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[5] = null;

        }
        else if (this.gameObject.name == "wind(Clone)")
        {
            PlayerIni.WindArrow = true;
            Debug.Log("Yes! Wind is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[6] = null;

        }
        else if (this.gameObject.name == "out(Clone)")
        {
            PlayerIni.DiagonalArrow =  true;
            Debug.Log("Yes! 多重射擊 is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[7] = null;
        }
        else if (this.gameObject.name == "plus(Clone)")
        {
            PlayerIni.FrontArrow = true;
            Debug.Log("Yes! 齊射 is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[8] = null;
        }
        else if (this.gameObject.name == "repeated(Clone)")
        {
            PlayerIni.Muitishot = true;
            Debug.Log("Yes! 連續射擊 is on!!!");
            //obj.GetComponent<FButtonInstantiate0>().Objects[9] = null;
        }
    }
}
