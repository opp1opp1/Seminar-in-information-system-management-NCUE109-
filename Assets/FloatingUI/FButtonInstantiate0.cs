using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonInstantiate0 : MonoBehaviour {  //隨機生成三個指定地點的隨機物件
    public GameObject point_01; //三個指定地點
    public GameObject point_02;
    public GameObject point_03;
    public GameObject[] Objects;    //隨機選擇物件
    public GameObject clone_01; //複製出來的物件
    public GameObject clone_02; //複製出來的物件
    public GameObject clone_03; //複製出來的物件
    public GameObject gameFPanel;   //複製出來後，要放到FPanel的層級底下
    public bool stop = true;   //避免無線複製，用來控制按鈕被點擊後立刻再生

    // Use this for initialization
    void Start () {
        gameFPanel = GameObject.Find("FPanel"); //拿來把clone放到FPanel底下之用        
    }

    // Update is called once per frame
    void Update () {  
		if(stop == true)    //if stop = true，再生; stop = false，暫時不再生
        {
            Ins_Objs1();
            Ins_Objs2();
            Ins_Objs3();
            stop = false;
        }
	}

    void Ins_Objs1()    //生成第一個點的物件
    {
        int Random_Objects = Random.Range(0, Objects.Length);   //隨機挑一個物件
        clone_01 = Instantiate(Objects[Random_Objects], point_01.transform.position,    //生成物件
            point_01.transform.rotation);
        clone_01.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
    }

    void Ins_Objs2()
    {
        int Random_Objects = Random.Range(0, Objects.Length);
        clone_02 = Instantiate(Objects[Random_Objects], point_02.transform.position,
            point_02.transform.rotation);
        clone_02.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
    }

    void Ins_Objs3()
    {
        int Random_Objects = Random.Range(0, Objects.Length);
        clone_03 = Instantiate(Objects[Random_Objects], point_03.transform.position,
            point_03.transform.rotation);
        clone_03.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
    }
}
