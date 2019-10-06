using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonInstantiate : MonoBehaviour //放在欲生成點上
{
    public GameObject Instantiate_FButton1;    //物件複製生成點
    public GameObject FButton1;    //要複製的物件
    public GameObject clone;    //複製出來的物件
    public GameObject gameFPanel;   //複製出來後，要放到FPanel的層級底下
    private bool stop = true;   //避免clone無限複製
    //new
                               
    void Start()
    { //一開始就執行生成物件
        gameFPanel = GameObject.Find("FPanel");
        //Instantiate_FButton1.transform.position = FButton1.transform.position;
        Instantiate_FButton1.transform.rotation = FButton1.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (FButton1.gameObject.activeSelf && stop == true)
        {
            clone = Instantiate(FButton1, Instantiate_FButton1.transform.position,  //生成(物件,位置,旋轉值)
            Instantiate_FButton1.transform.rotation);                       //Instantiate實例化
            clone.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
            clone.SetActive(true);  //讓clone顯現
            stop = false;   //避免無限複製
            Debug.Log("hit");
        }

    }
}
