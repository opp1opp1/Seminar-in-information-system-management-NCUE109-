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
            /*obj.GetComponent<FButtonInstantiate0>().Objects[3] = null;
            for(int i = 3; i < obj.GetComponent<FButtonInstantiate0>().Objects.Length; i++)
            {
                obj.GetComponent<FButtonInstantiate0>().Objects[i] = obj.GetComponent<FButtonInstantiate0>().Objects[i + 1];
            }
            obj.GetComponent<FButtonInstantiate0>().Objects.*/
        }
        if (this.gameObject.name == "fire(Clone)")
        {
            PlayerIni.FireArrow = true;
            Debug.Log("Yes! Fire is on!!!");
        }
        if (this.gameObject.name == "ice(Clone)")
        {
            PlayerIni.IceArrow = true;
            Debug.Log("Yes! Ice is on!!!");
        }
        if (this.gameObject.name == "wind(Clone)")
        {
            PlayerIni.WindArrow = true;
            Debug.Log("Yes! Wind is on!!!");
        }
    }
}
