using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行


public class HitHpScript : MonoBehaviour {
    private float lastHealth;
    private float HitHealth;
    private GameObject Enemy;
    private GameObject Hp2;
    public float Disappertimer ;
    public float Hp2Disappertimer;
    // Use this for initialization
    void Start () {
        Enemy =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject;
        Hp2 = gameObject.transform.parent.gameObject.gameObject.transform.GetChild(2).gameObject;
        lastHealth = Enemy.GetComponent<EnemyStat>().currentenemyhealth;
    }
	
	// Update is called once per frame
	void Update () {
        Disappertimer -= Time.fixedDeltaTime;
        Hp2Disappertimer -= Time.fixedDeltaTime;
        if (Enemy.GetComponent<EnemyStat>().currentenemyhealth != lastHealth)
        {
            HitHealth = lastHealth - Enemy.GetComponent<EnemyStat>().currentenemyhealth;
            if (this.GetComponent<Text>().text != "")
            {
                Hp2.GetComponent<Text>().text = this.GetComponent<Text>().text;
                Hp2Disappertimer = 0.7f - Disappertimer;
            }
            
                this.GetComponent<Text>().text = "" + HitHealth +"!";
            
            
            lastHealth = Enemy.GetComponent<EnemyStat>().currentenemyhealth;
            Disappertimer = 0.7f;
            
        }
        if (Disappertimer <= 0f)
        {
            this.GetComponent<Text>().text = "";
        }
        if (Hp2Disappertimer <= 0f)
        {
            Hp2.GetComponent<Text>().text = "";
        }
    }
}
