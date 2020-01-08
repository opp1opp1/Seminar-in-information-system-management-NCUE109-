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
    public float agentspeed;
    public float BurnGroundTime =2.0f;
    public float IceGroundTime = 0.5f;




    // Use this for initialization
    void Awake () {
        
        switch (enemytype) //根據敵人種類，有不同的血量
            {
                case 1:
                    basicenemyhealth = 100;
                enemyattackspeed = 1f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                agentspeed = 5f;
                    break;
                case 2:
                    basicenemyhealth = 60;
                enemyattackspeed = 1f;
                ColliderDamage = 5f;
                WakeUpDistance = 8f;
                agentspeed = 10f;
                    break;
                case 3:
                    basicenemyhealth = 700;
                enemyattackspeed = 2f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                AttackDistance = 2f;
                agentspeed = 7f;
                break;
            case 4:
                basicenemyhealth = 150;
                enemyattackspeed = 1f;
                ColliderDamage = 5f;
                WakeUpDistance = 8f;
                agentspeed = 10f;
                break;
            case 5:
                basicenemyhealth = 50;
                enemyattackspeed = 0.7f;
                ColliderDamage = 15f;
                WakeUpDistance = 8f;
                agentspeed = 4f;
                break;
            case 6:
                basicenemyhealth = 50;
                enemyattackspeed = 1f;
                ColliderDamage = 0f;
                WakeUpDistance = 16f;
                AttackDistance = 2f;
                agentspeed = 5f;
                break;
            case 7:
                basicenemyhealth = 100;
                enemyattackspeed = 1f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                agentspeed = 0f;
                break;
            case 8:
                basicenemyhealth = 100;
                enemyattackspeed = 1f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                agentspeed = 5f;
                break;
            case 9:
                basicenemyhealth = 1000;
                enemyattackspeed = 1f;
                ColliderDamage = 20f;
                WakeUpDistance = 15f;
                AttackDistance = 3.5f;
                agentspeed = 2f;
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
