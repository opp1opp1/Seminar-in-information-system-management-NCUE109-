using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonInstantiate2 : MonoBehaviour
{
    public GameObject Instantiate_FButton2;    //物件複製生成點
    public GameObject FButton;    //要複製的物件
    public GameObject clone2;    //複製出來的物件
    public GameObject gameFPanel;   //複製出來後，要放到FPanel的層級底下
    private bool stop = true;   //避免clone無限複製
                                // Use this for initialization
    void Start () {
        gameFPanel = GameObject.Find("FPanel"); //拿來把clone放到FPanel底下之用
    }

    // Update is called once per frame
    void Update () {
        if (FButton.gameObject.activeSelf && stop == true)
        {
            clone2 = Instantiate(FButton, Instantiate_FButton2.transform.position,  //生成(物件,位置,旋轉值)
                Instantiate_FButton2.transform.rotation);                       //Instantiate實例化
            clone2.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
            clone2.SetActive(true);  //讓clone顯現
            stop = false;   //避免無限複製
            Debug.Log("hit");
        }
    }
}
