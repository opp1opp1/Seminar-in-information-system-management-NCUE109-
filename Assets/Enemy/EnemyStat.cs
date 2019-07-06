using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour {
    public int enemytype; //用以判斷enemy的種類
    public float basicenemyhealth; //初始enemy的血量
    public float currentenemyhealth; //enemy的血量
    public float enemyattackspeed;//enemy的攻擊速度
    
    private GameObject self;
    private GameObject bullet;
    private float bulletdamage;

    
 


    // Use this for initialization
    void Start () {

        switch (enemytype) //根據敵人種類，有不同的血量
            {
                case 1:
                    basicenemyhealth = 100;
                enemyattackspeed = 1f;
                    break;
                case 2:
                    basicenemyhealth = 60;
                enemyattackspeed = 1f;
                    break;
                default:
                    Debug.Log("enemy dont have health");
                    break;
            }
        currentenemyhealth = basicenemyhealth;

    }
    private void OnTriggerEnter(Collider other) //偵測敵人本身有沒有跟弓箭產生碰撞
    {
        
        
        
        if (other.tag == "Bullet")      //如果碰到的物體tag為Bullet
        {

            bullet = GameObject.Find("Ashe_Arrow(Clone)");
            bulletdamage = bullet.GetComponent<bulletdestroy>().bullet_damage; //取得弓箭的傷害

            self = this.gameObject;
            currentenemyhealth -= bulletdamage;

            Debug.Log("EnemyHealth:" + currentenemyhealth);

                if (currentenemyhealth <= 0)  //如果敵人血量低於0就掰掰
                {
                    Destroy(gameObject);
                }
        }
    }
    // Update is called once per frame
    void Update () {

    }
    
}
