using System.Collections;
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
    public void OnClick()
    {
        if (this.gameObject.name == "earth(Clone)")
        {
            PlayerIni.EarthArrow = true;
            Debug.Log("Yes! Earth is on!!!");
            obj.GetComponent<FButtonInstantiate0>().Objects[3] = null;
        }
        if (this.gameObject.name == "fire(Clone)")
        {
            PlayerIni.FireArrow = true;
            Debug.Log("Yes! Fire is on!!!");
            obj.GetComponent<FButtonInstantiate0>().Objects[4] = null;

        }
        if (this.gameObject.name == "ice(Clone)")
        {
            PlayerIni.IceArrow = true;
            Debug.Log("Yes! Ice is on!!!");
            obj.GetComponent<FButtonInstantiate0>().Objects[5] = null;

        }
        if (this.gameObject.name == "wind(Clone)")
        {
            PlayerIni.WindArrow = true;
            Debug.Log("Yes! Wind is on!!!");
            obj.GetComponent<FButtonInstantiate0>().Objects[6] = null;

        }
    }
}
