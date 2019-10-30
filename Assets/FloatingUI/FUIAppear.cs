using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUIAppear : MonoBehaviour {//套在Ashe身上
    
    GameObject gameFPanel;
	// Use this for initialization
	void Start () {
        gameFPanel = GameObject.Find("FPanel"); //找到FPanel
        gameFPanel.SetActive(false);    //先設置FPanel隱藏
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}
    private void OnTriggerEnter(Collider col)   //碰撞事件:用Trigger和Collider，因為是要碰撞到可穿透的物件
    {
        if(col.gameObject.name == "powerup(Clone)") //如果Ashe撞到powerup
        {
            
            gameFPanel.gameObject.SetActive(true);  //產生FPanel
            Destroy(col.gameObject);    //摧毀powerup
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        
    }
}
