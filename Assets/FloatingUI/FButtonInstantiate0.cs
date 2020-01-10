using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonInstantiate0 : MonoBehaviour
{  //隨機生成三個指定地點的隨機物件
    public GameObject point_01; //三個指定地點
    public GameObject point_02;
    public GameObject point_03;
    public GameObject[] Objects;    //隨機選擇物件
    public GameObject clone_01; //複製出來的物件
    public GameObject clone_02; //複製出來的物件
    public GameObject clone_03; //複製出來的物件
    public GameObject gameFPanel;   //複製出來後，要放到FPanel的層級底下
    public bool stop = false;   //避免無線複製，用來控制按鈕被點擊後立刻再生

    // Use this for initialization
    void Start()
    {
        gameFPanel = GameObject.Find("FPanel"); //拿來把clone放到FPanel底下之用
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)    //if stop = true，再生; stop = false，暫時不再生
        {
            Ins_Objs1();
            stop = false;
        }
    }

    int Ins_Objs1()    //生成第一個點的物件
    {
        bool[] RepeatTable = new bool[10];

        for (int i = 0; i <= 9; i++)
            RepeatTable[i] = false;

        //if(Random_Objects == 3)
        {
            if (PlayerIni.EarthArrow == true)
            {
                RepeatTable[3] = true;
            }
        }
        //if (Random_Objects == 4)
        {
            if (PlayerIni.FireArrow == true)
            {
                RepeatTable[4] = true;
            }
            //if (Random_Objects == 5)
            {
                if (PlayerIni.IceArrow == true)
                {
                    RepeatTable[5] = true;
                }
            }
            //if (Random_Objects == 6)
            {
                if (PlayerIni.WindArrow == true)
                {
                    RepeatTable[6] = true;
                }
            }
            //if (Random_Objects == 7)
            {
                if (PlayerIni.DiagonalArrow == true)
                {
                    RepeatTable[7] = true;
                }
            }
            //if (Random_Objects == 8)
            {
                if (PlayerIni.FrontArrow == true)
                {
                    RepeatTable[8] = true;
                }
            }
            //if (Random_Objects == 9)
            {
                if (PlayerIni.Muitishot == true)
                {
                    RepeatTable[9] = true;
                }
            }

            int Random1, Random2, Random3;

            Random1 = Random.Range(0, Objects.Length);
            while (RepeatTable[Random1] == true)   //隨機挑一個物件
                Random1 = Random.Range(0, Objects.Length);

            Random2 = Random.Range(0, Objects.Length);
            while (RepeatTable[Random2] == true)   //隨機挑一個物件
                Random2 = Random.Range(0, Objects.Length);

            Random3 = Random.Range(0, Objects.Length);
            while (RepeatTable[Random3] == true)   //隨機挑一個物件
                Random3 = Random.Range(0, Objects.Length);

            clone_01 = Instantiate(Objects[Random1], point_01.transform.position, point_01.transform.rotation);//生成物件
            clone_01.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
            clone_02 = Instantiate(Objects[Random2], point_02.transform.position, point_02.transform.rotation);//生成物件
            clone_02.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
            clone_03 = Instantiate(Objects[Random3], point_03.transform.position, point_03.transform.rotation);//生成物件
            clone_03.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
            return 0;
        }
        /*
            int Ins_Objs2()
            {
                int Random_Objects = Random.Range(0, Objects.Length);
                if (Random_Objects == 3)
                {
                    if (PlayerIni.EarthArrow == true)
                    {
                        return Ins_Objs2();
                    }
                }
                if (Random_Objects == 4)
                {
                    if (PlayerIni.FireArrow == true)
                    {
                        return Ins_Objs2();
                    }
                }
                if (Random_Objects == 5)
                {
                    if (PlayerIni.IceArrow == true)
                    {
                        return Ins_Objs2();
                    }
                }
                if (Random_Objects == 6)
                {
                    if (PlayerIni.WindArrow == true)
                    {
                        return Ins_Objs2();
                    }
                }
                if (Random_Objects == 7)
                {
                    if (PlayerIni.DiagonalArrow == true)
                    {
                        return Ins_Objs2();
                    }
                }
                if (Random_Objects == 8)
                {
                    if (PlayerIni.FrontArrow == true)
                    {
                        return Ins_Objs2();
                    }
                }
                if (Random_Objects == 9)
                {
                    if (PlayerIni.Muitishot == true)
                    {
                        return Ins_Objs2();
                    }
                }
                clone_02 = Instantiate(Objects[Random_Objects], point_02.transform.position,
                    point_02.transform.rotation);
                clone_02.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
                return 0;
            }

            int Ins_Objs3()
            {
                int Random_Objects = Random.Range(0, Objects.Length);
                if (Random_Objects == 3)
                {
                    if (PlayerIni.EarthArrow == true)
                    {
                        return Ins_Objs3();
                    }
                }
                if (Random_Objects == 4)
                {
                    if (PlayerIni.FireArrow == true)
                    {
                        return Ins_Objs3();
                    }
                }
                if (Random_Objects == 5)
                {
                    if (PlayerIni.IceArrow == true)
                    {
                        return Ins_Objs3();
                    }
                }
                if (Random_Objects == 6)
                {
                    if (PlayerIni.WindArrow == true)
                    {
                        return Ins_Objs3();
                    }
                }
                if (Random_Objects == 7)
                {
                    if (PlayerIni.DiagonalArrow == true)
                    {
                        return Ins_Objs3();
                    }
                }
                if (Random_Objects == 8)
                {
                    if (PlayerIni.FrontArrow == true)
                    {
                        return Ins_Objs3();
                    }
                }
                if (Random_Objects == 9)
                {
                    if (PlayerIni.Muitishot == true)
                    {
                        return Ins_Objs3();
                    }
                }
                clone_03 = Instantiate(Objects[Random_Objects], point_03.transform.position,
                    point_03.transform.rotation);
                clone_03.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
                return 0;
            }*/
    }
}