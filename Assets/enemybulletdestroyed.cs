using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybulletdestroyed : MonoBehaviour {

    private float lifeTime;
    public float maxTime = 3.0f;
    private GameObject target;
    private float targethealth;
    public float bullet_damage = 5.0f;
    // Use this for initialization
    void Start()
    {
        lifeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxTime)
        {
            Destroy(gameObject);
        }

    }

    //弓箭射到物體時消失
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = GameObject.Find("Ashe");
            targethealth = target.GetComponent<PlayerStats>().currentHealth;
            targethealth -= bullet_damage;
            target.GetComponent<PlayerStats>().currentHealth = targethealth;
            Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth);
            Destroy(gameObject);
        }
    }
}
