using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealthbar : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    private GameObject target;
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Enemy1");
    }

    // Update is called once per frame
    void Update()
    {

        currentHP = target.GetComponent<EnemyStat>().currentenemyhealth;
        maxHP = target.GetComponent<EnemyStat>().basicenemyhealth;
        this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
    }
}
