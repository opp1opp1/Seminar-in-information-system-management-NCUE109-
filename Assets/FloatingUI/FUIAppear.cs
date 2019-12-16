﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUIAppear : MonoBehaviour {//套在Ashe身上
    public GameObject gameFPanel;
    public bool isPaused = false;    //讓update裡的動作暫停
    public GameObject stop_button; //用來在選擇能力時將暫停鈕隱藏，避免選擇能力時觸碰到暫停鈕
    public int st;

	// Use this for initialization
	void Awake () {
        gameFPanel = GameObject.Find("FPanel"); //找到FPanel
        gameFPanel.SetActive(false);    //先設置FPanel隱藏
        stop_button = GameObject.Find("stop_button");   //找到stop_button
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerEnter(Collider col)   //碰撞事件:用Trigger和Collider，因為是要碰撞到可穿透的物件
    {
        if(col.gameObject.name == "powerup(Clone)"|| col.gameObject.name == "powerup(Tutorial)") //如果Ashe撞到powerup
        {
            gameFPanel.GetComponent<FButtonInstantiate0>().stop = true; //吃到powerup時則會出現panel
            gameFPanel.gameObject.SetActive(true);  //顯示FPanel
            Vector3 st = stop_button.transform.position;    //暫時隱藏暫停鈕
            st = new Vector3(st.x - 1000, st.y, st.z);
            stop_button.transform.position = st;
            Destroy(col.gameObject);    //摧毀powerup
            PauseGame();    //暫停遊戲
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
}
