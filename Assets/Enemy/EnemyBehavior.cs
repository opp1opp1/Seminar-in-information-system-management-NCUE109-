using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject Player;
    public float WakeUpDistance = 10.0f;
    public float ColliderDamage = 5.0f;
    private GameObject target;
    private GameObject arrow;
    private float targethealth;
    private float EAS;
    private float EASChecker;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EAS = this.GetComponent<EnemyStat>().enemyattackspeed;
        EASChecker = EAS;
    }

    // Update is called once per frame
    void Update()
    {
        EASChecker -= Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < WakeUpDistance)
        {
            //Vector3 dirToPlayer = transform.position - Player.transform.position;
            //Vector3 newPos = transform.position + dirToPlayer;
            Vector3 newPos = Player.transform.position;
            agent.SetDestination(newPos);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ashe")
        {
            if(EASChecker<=0)
            target = GameObject.Find("Ashe");
            targethealth =target.GetComponent<PlayerStats>().currentHealth;
            targethealth -= ColliderDamage;
            target.GetComponent<PlayerStats>().currentHealth = targethealth;
            Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth);
            EASChecker = EAS;
        }
    }

    

}