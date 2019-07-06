using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealthbar : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    private GameObject target;
    private GameObject target2;
    private GameObject target3;
    // Use this for initialization
    void Start()
    {
        target3 = gameObject.transform.parent.gameObject;
        target2 = target3.transform.parent.gameObject;
        target = target2.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        currentHP = target.GetComponent<EnemyStat>().currentenemyhealth;
        maxHP = target.GetComponent<EnemyStat>().basicenemyhealth;
        this.transform.localPosition = new Vector3(-105 + 105 * (currentHP / maxHP), 0.0f, 0.0f);
    }
}
