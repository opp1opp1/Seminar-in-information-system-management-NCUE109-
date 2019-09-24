using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour {
    public int enemytype; //用以判斷enemy的種類
    public float basicenemyhealth; //初始enemy的血量
    public float currentenemyhealth; //enemy的血量
    public float enemyattackspeed;//enemy的攻擊速度
    public float ColliderDamage;
    public float WakeUpDistance;
    public float AttackDistance;
    public float agantspeed;
    public float BurnGroundTime =2.0f;
    public float IceGroundTime = 0.5f;




    // Use this for initialization
    void Start () {

        switch (enemytype) //根據敵人種類，有不同的血量
            {
                case 1:
                    basicenemyhealth = 100;
                enemyattackspeed = 1f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                agantspeed = 5f;
                    break;
                case 2:
                    basicenemyhealth = 60;
                enemyattackspeed = 1f;
                ColliderDamage = 5f;
                WakeUpDistance = 8f;
                agantspeed = 10f;
                break;
                case 3:
                    basicenemyhealth = 700;
                enemyattackspeed = 2f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                AttackDistance = 2f;
                agantspeed = 7f;
                break;
            default:
                    Debug.Log("enemy dont have health");
                    break;
            }
        currentenemyhealth = basicenemyhealth;

    }
    
    // Update is called once per frame
    void Update () {
       
    }
    
}
