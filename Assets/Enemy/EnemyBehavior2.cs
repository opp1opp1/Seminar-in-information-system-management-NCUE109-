using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior2 : MonoBehaviour {
    public GameObject bullet;
    private NavMeshAgent agent;
    private GameObject Player;
    public float WakeUpDistance = 10.0f;
    public float ColliderDamage = 5.0f;
    private GameObject target;
    private float targethealth;
    private float EAS;
    private float EASChecker;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Ashe");
        agent = GetComponent<NavMeshAgent>();
        EAS = this.GetComponent<EnemyStat>().enemyattackspeed;
        EASChecker = EAS;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        EASChecker -= Time.deltaTime;
        if (distance < WakeUpDistance)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            //Vector3 newPos = transform.position ;
            agent.SetDestination(newPos);
        }
        else
        {
            if (EASChecker <= 0)
            {
                target = GameObject.Find("Ashe");
                transform.LookAt(target.transform.position);
                Instantiate(bullet, transform.position, transform.rotation);
                EASChecker = EAS;
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Ashe")
        {
            if (EASChecker <= 0)
            {
                target = GameObject.Find("Ashe");
                targethealth = target.GetComponent<PlayerStats>().currentHealth;
                targethealth -= ColliderDamage;
                target.GetComponent<PlayerStats>().currentHealth = targethealth;
                Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth);
                EASChecker = EAS;
            }
        }
    }
}
