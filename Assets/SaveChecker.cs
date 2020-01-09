using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChecker : MonoBehaviour {
    //PlayerPrefs.SetFloat (“儲存名稱TAGF", 浮點數變數);
    //浮點數變數 = PlayerPrefs.GetFloat (“儲存名稱TAGF");
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetFloat("Health") == 0)
        {
            PlayerPrefs.SetFloat("Health", 100.0F);
        }
        if (PlayerPrefs.GetFloat("Attack") == 0)
        {
            PlayerPrefs.SetFloat("Attack", 20.0F);
        }
        if (PlayerPrefs.GetFloat("AttackSpeed") == 0)
        {
            PlayerPrefs.SetFloat("AttackSpeed", 1.0F);
        }
        if (PlayerPrefs.GetFloat("Money") == 0)
        {
            PlayerPrefs.SetFloat("Money", 200);
        }
        PlayerPrefs.GetFloat("Money");
        PlayerPrefs.GetFloat("Tutotial");
        /*PlayerPrefs.DeleteAll(); 
        清除存檔用*/
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
