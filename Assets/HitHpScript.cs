using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行


public class HitHpScript : MonoBehaviour {
    private float lastHealth;
    private float HitHealth;
    private GameObject Enemy;
    public float Disappertimer ;
    // Use this for initialization
	void Start () {
        Enemy =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject;
        lastHealth = Enemy.GetComponent<EnemyStat>().currentenemyhealth;
    }
	
	// Update is called once per frame
	void Update () {
        Disappertimer -= Time.fixedDeltaTime;
        if (Enemy.GetComponent<EnemyStat>().currentenemyhealth != lastHealth)
        {
            HitHealth = lastHealth - Enemy.GetComponent<EnemyStat>().currentenemyhealth;
            this.GetComponent<Text>().text = "" + HitHealth +"!";
            lastHealth = Enemy.GetComponent<EnemyStat>().currentenemyhealth;
            Disappertimer = 0.7f;
            
        }
        if (Disappertimer <= 0f)
        {
            this.GetComponent<Text>().text = "";
        }
    }
}
