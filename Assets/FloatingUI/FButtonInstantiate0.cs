using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonInstantiate0 : MonoBehaviour {
    public GameObject[] Objects;
    public Transform[] Points;
    public GameObject clone0;    //複製出來的物件
    public GameObject gameFPanel;   //複製出來後，要放到FPanel的層級底下

    // Use this for initialization
    void Start () {
        gameFPanel = GameObject.Find("FPanel"); //拿來把clone放到FPanel底下之用
        Ins_Objs();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Ins_Objs()
    {
        int Random_Objects = Random.Range(0, Objects.Length);
        int Random_Points = Random.Range(0, Points.Length);
        clone0 = Instantiate(Objects[Random_Objects], Points[Random_Points].transform.position, 
            Points[Random_Points].transform.rotation);
        clone0.transform.parent = gameFPanel.transform;  //複製出FButton後，將他放到FPanel底下，才顯現得出來
        Debug.Log("hitme");
    }
}
