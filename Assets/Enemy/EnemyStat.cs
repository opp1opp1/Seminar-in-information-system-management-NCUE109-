using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour {
    public int enemytype; //用以判斷enemy的種類
    public float enemyhealth; //enemy的血量


	// Use this for initialization
	void Start () {

        switch (enemytype) //根據敵人種類，有不同的血量
            {
                case 1:
                    enemyhealth = 100;
                    break;
                case 2:
                    enemyhealth = 60;
                    break;
                default:
                    Debug.Log("enemy dont have health");
                    break;
            }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
