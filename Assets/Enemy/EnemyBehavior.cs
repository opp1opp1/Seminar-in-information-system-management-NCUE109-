using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject Player;
    public float WakeUpDistance = 10.0f;
    public float ColliderDamage = 5.0f;
    private GameObject target;
    private GameObject arrow;
    private float targethealth;
    private float targetShield;
    private float EAS;
    private float EASChecker;
    public float agentspeed  ;
    private float slowagentspeed;
    public float slowtimer = 0f;
    public float burntimer = 0f;
    private float burncounter = 0f;
    public float burndamage;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Ashe");
        agent = GetComponent<NavMeshAgent>();
        agentspeed = 5.0f;
        GetComponent<NavMeshAgent>().speed = agentspeed;
        EAS = this.GetComponent<EnemyStat>().enemyattackspeed;
        EASChecker = EAS;
        slowagentspeed = agentspeed * 0.75f;
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
        if (slowtimer > 0.1f)
        {
            slowtimer -= Time.deltaTime;
            
            GetComponent<NavMeshAgent>().speed = slowagentspeed;
        }
        else if (slowtimer <= 0.0f)
        {
            slowtimer = 0f;
            GetComponent<NavMeshAgent>().speed = agentspeed;
        }
        if (burntimer > 0.1f)
        {
            burncounter += Time.deltaTime;
            burntimer -= Time.deltaTime;
            if(burncounter >=1.0f)
            {
                GetComponent<EnemyStat>().currentenemyhealth -= burndamage;
                Debug.Log("EnemyHealth:" + GetComponent<EnemyStat>().currentenemyhealth);
                burncounter = 0f;
            }
            


        }
        else if (burntimer <= 0.0f)
        {
            burntimer = 0f;
            burncounter = 0f;

        }
        //TEST IT works!
        //agentspeed = 10.0f;
        // GetComponent<NavMeshAgent>().speed = agentspeed;
        Quaternion.LookRotation(Player.transform.position-this.transform.position);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Ashe")
        {
            if (EASChecker <= 0)
            {
                target = GameObject.Find("Ashe");
                targetShield = target.GetComponent<PlayerStats>().currentSheild;
                if (targetShield >= ColliderDamage)
                {
                    targetShield -= ColliderDamage;
                    target.GetComponent<PlayerStats>().currentSheild = targetShield;
                }
                else if (targetShield < ColliderDamage)
                {
                    target.GetComponent<PlayerStats>().currentSheild = 0;
                    ColliderDamage -= targetShield;
                    if (ColliderDamage > 0)
                    {
                    targethealth = target.GetComponent<PlayerStats>().currentHealth;
                    targethealth -= ColliderDamage;
                    target.GetComponent<PlayerStats>().currentHealth = targethealth;
                    }
                }
                Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth+ "Sheild:"+ target.GetComponent<PlayerStats>().currentSheild);
                    EASChecker = EAS;
            }
        }
    }

    

}