using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonInstantiate : MonoBehaviour
{
    public GameObject Instantiate_FButton1;    //物件生成點
    public GameObject FButton1;    //要生成的物件
                                   // Use this for initialization
    void Start()
    { //一開始就執行生成物件

    }

    // Update is called once per frame
    void Update()
    {
        if (FButton1.gameObject.activeSelf)
        {
            Instantiate(FButton1, Instantiate_FButton1.transform.position,  //生成(物件,位置,旋轉值)
            Instantiate_FButton1.transform.rotation);                       //Instantiate實例化
            Debug.Log("hit");
        }
    }
}
