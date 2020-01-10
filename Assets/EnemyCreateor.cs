using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateor : MonoBehaviour {
    public GameObject[] Objects;
    public Transform[] Points;
    public float Ins_Time = 3;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Ins_Objs", Ins_Time, Ins_Time);
    }
	
	// Update is called once per frame
	void Update () {
    }
    void Ins_Objs() //生成物件函式。

    {

        int Random_Objects = Random.Range(0, Objects.Length);

        int Random_Points = Random.Range(0, Points.Length);

        Instantiate(Objects[Random_Objects], Points[Random_Points].transform.position, Points[Random_Points].transform.rotation);

    }
}
