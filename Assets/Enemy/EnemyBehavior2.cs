﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior2 : MonoBehaviour {
    public GameObject bullet;
    private NavMeshAgent agent;
    public GameObject Player;
    public float WakeUpDistance = 10.0f;
    public float ColliderDamage = 5.0f;
    private GameObject target;
    private float targethealth;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < WakeUpDistance)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            //Vector3 newPos = transform.position ;
            agent.SetDestination(newPos);
        }
        else
        {
            target = GameObject.Find("Ashe");
            transform.LookAt(target.transform.position);
            Instantiate(bullet, transform.position, transform.rotation);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ashe")
        {
           // target = GameObject.Find("Ashe");
            targethealth = target.GetComponent<PlayerStats>().currentHealth;
            targethealth -= ColliderDamage;
            target.GetComponent<PlayerStats>().currentHealth = targethealth;
            Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth);
        }
    }
}
