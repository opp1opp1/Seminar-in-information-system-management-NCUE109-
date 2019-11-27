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
            PlayerPrefs.SetFloat("Health", 120.0F);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
