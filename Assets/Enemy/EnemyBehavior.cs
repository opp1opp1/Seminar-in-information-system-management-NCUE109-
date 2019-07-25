using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Enemy2_bullet;
    private NavMeshAgent agent;
    private GameObject Player;
    //public float WakeUpDistance;
    //public float ColliderDamage;
    private GameObject target;
    private GameObject arrow;
    private float targethealth;
    private float targetShield;
    private float EAS;
    private float EASChecker;
    public float agentspeed ;
    private float slowagentspeed;
    public float slowtimer = 0f;
    public float burntimer = 0f;
    private float burncounter = 0f;
    public float burndamage;
    private float tempDamage;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Ashe");
        agent = GetComponent<NavMeshAgent>();
        agentspeed = GetComponent<EnemyStat>().agantspeed;
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
        if (this.gameObject.tag=="Enemy_1")
        {
            if (distance <= this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                //Vector3 dirToPlayer = transform.position - Player.transform.position;
                //Vector3 newPos = transform.position + dirToPlayer;
                Vector3 newPos = Player.transform.position;
                agent.SetDestination(newPos);

            }
        }
        else if (this.gameObject.tag==  ("Enemy_2"))
        {
            if (distance < this.GetComponent<EnemyStat>().WakeUpDistance)
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
                    Instantiate(Enemy2_bullet, transform.position, transform.rotation);
                    EASChecker = EAS;
                }
            }
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
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Enemy_1")
        {
            if (other.name == "Ashe")
            {
                if (EASChecker <= 0)
                {
                    
                    target = GameObject.Find("Ashe");
                    if (target.GetComponent<PlayerStats>().itisinvincinble != true)
                    { 
                        targetShield = target.GetComponent<PlayerStats>().currentSheild;
                        
                        if (targetShield >= GetComponent<EnemyStat>().ColliderDamage)
                        {
                            targetShield -= GetComponent<EnemyStat>().ColliderDamage;
                            target.GetComponent<PlayerStats>().currentSheild = targetShield;
                        }
                        else if (targetShield < GetComponent<EnemyStat>().ColliderDamage)
                        {
                            tempDamage = GetComponent<EnemyStat>().ColliderDamage;                       
                            tempDamage -= targetShield;
                            target.GetComponent<PlayerStats>().currentSheild = 0;
                        if (tempDamage > 0)
                        {
                            targethealth = target.GetComponent<PlayerStats>().currentHealth;
                            targethealth -= tempDamage;
                            target.GetComponent<PlayerStats>().currentHealth = targethealth;
                        }
                    }
                    else
                        {
                            Debug.Log("invincinble");
                        }
                        if (target.GetComponent<PlayerStats>().reflectdamage == true)
                        {
                            GetComponent<EnemyStat>().currentenemyhealth -= GetComponent<EnemyStat>().ColliderDamage * target.GetComponent<PlayerStats>().reflectdamageratio;
                        }
                        Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth + "Sheild:" + target.GetComponent<PlayerStats>().currentSheild+"EnemyHealth"+GetComponent<EnemyStat>().currentenemyhealth);
                    EASChecker = EAS;
                    }
                }
            }
        }
        else if (gameObject.tag == "Enemy_2")
        {
            if (other.name == "Ashe")
            {
                if (EASChecker <= 0)
                {
                    target = GameObject.Find("Ashe");
                    if (target.GetComponent<PlayerStats>().itisinvincinble != true)
                    {
                        targetShield = target.GetComponent<PlayerStats>().currentSheild;
                        if (targetShield >= GetComponent<EnemyStat>().ColliderDamage)
                        {
                            targetShield -= GetComponent<EnemyStat>().ColliderDamage;
                            target.GetComponent<PlayerStats>().currentSheild = targetShield;
                        }
                        else if (targetShield < GetComponent<EnemyStat>().ColliderDamage)
                        {

                            GetComponent<EnemyStat>().ColliderDamage = tempDamage;
                            tempDamage -= targetShield;
                            target.GetComponent<PlayerStats>().currentSheild = 0;
                            if (tempDamage > 0)
                            {
                                targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                targethealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = targethealth;
                            }
                        }
                else
                     {
                        Debug.Log("invincinble");
                     }
                if (target.GetComponent<PlayerStats>().reflectdamage == true)
                    {
                        GetComponent<EnemyStat>().currentenemyhealth -= GetComponent<EnemyStat>().ColliderDamage * target.GetComponent<PlayerStats>().reflectdamageratio;
                    }
                        Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth + "Sheild:" + target.GetComponent<PlayerStats>().currentSheild);
                        EASChecker = EAS;
                    }
                }
            }
        }
        }

    

}