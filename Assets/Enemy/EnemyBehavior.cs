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
    public GameObject PowerUp;
    private float targethealth;
    private float targetShield;
    private float EAS;
    private float EASChecker;
    public float agentspeed;
    private float slowagentspeed;
    public float slowtimer = 0f;
    public float burntimer = 0f;
    private float burncounter = 0f;
    public float burndamage;
    private float tempDamage;
    public float stuntimer = 0f;
    private bool Instantiateonce = false;
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
        if (GetComponent<EnemyStat>().currentenemyhealth <= 0)  //如果敵人血量低於0就掰掰
        {
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Enemy_1")
        {
            if (distance <= this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                //Vector3 dirToPlayer = transform.position - Player.transform.position;
                //Vector3 newPos = transform.position + dirToPlayer;
                Vector3 newPos = Player.transform.position;
                agent.SetDestination(newPos);

            }
        }
        else if (this.gameObject.tag == ("Enemy_2"))
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
        if (stuntimer > 0.1f)
        {
            stuntimer -= Time.deltaTime;

            GetComponent<NavMeshAgent>().speed = 0f;
        }
        else if (stuntimer <= 0.0f)
        {
            stuntimer = 0f;
            GetComponent<NavMeshAgent>().speed = agentspeed;
        }
        if (burntimer >  0f)
        {
            burncounter += Time.deltaTime;
            burntimer -= Time.deltaTime;
            if (burncounter >= 1.0f)
            {
                GetComponent<EnemyStat>().currentenemyhealth -= burndamage;
                Debug.Log("EnemyHealth:" + GetComponent<EnemyStat>().currentenemyhealth);
                burncounter = 0f;
            }

        }
        if (burntimer >= 2.0f)
        {
            burntimer = 2.0f;
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
                        if (target.GetComponent<PlayerStats>().reducedamage == true)
                        {
                            tempDamage = GetComponent<EnemyStat>().ColliderDamage * 0.8f;
                            if (targetShield >= tempDamage)
                            {
                                targetShield -= tempDamage;
                                target.GetComponent<PlayerStats>().currentSheild = targetShield;
                            }
                            else
                            {
                                tempDamage -= targetShield;
                                target.GetComponent<PlayerStats>().currentSheild = 0;
                                if (tempDamage > 0)
                                {
                                    targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                    targethealth -= tempDamage;
                                    target.GetComponent<PlayerStats>().currentHealth = targethealth;

                                }
                            }
                        }
                        else
                        {
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
                            }
                            if (tempDamage > 0)
                            {
                                targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                targethealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = targethealth;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("invincinble");
                    }
                        }
                    if (target.GetComponent<PlayerStats>().reflectdamage == true)
                    {
                        GetComponent<EnemyStat>().currentenemyhealth -= GetComponent<EnemyStat>().ColliderDamage * target.GetComponent<PlayerStats>().reflectdamageratio;
                    }
                    Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth + "Sheild:" + target.GetComponent<PlayerStats>().currentSheild + "EnemyHealth" + GetComponent<EnemyStat>().currentenemyhealth);
                    EASChecker = EAS;
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
                        if (target.GetComponent<PlayerStats>().reducedamage == true)
                        {
                            tempDamage = GetComponent<EnemyStat>().ColliderDamage * 0.8f;
                            if (targetShield >= tempDamage)
                            {
                                targetShield -= tempDamage;
                                target.GetComponent<PlayerStats>().currentSheild = targetShield;
                            }
                            else
                            {
                                tempDamage -= targetShield;
                                target.GetComponent<PlayerStats>().currentSheild = 0;
                                if (tempDamage > 0)
                                {
                                    targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                    targethealth -= tempDamage;
                                    target.GetComponent<PlayerStats>().currentHealth = targethealth;

                                }
                            }
                        }
                        else
                        {
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
                            }
                            if (tempDamage > 0)
                            {
                                targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                targethealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = targethealth;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("invincinble");
                    }
                }
                if (target.GetComponent<PlayerStats>().reflectdamage == true)
                {
                    GetComponent<EnemyStat>().currentenemyhealth -= GetComponent<EnemyStat>().ColliderDamage * target.GetComponent<PlayerStats>().reflectdamageratio;
                }
                Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth + "Sheild:" + target.GetComponent<PlayerStats>().currentSheild + "EnemyHealth" + GetComponent<EnemyStat>().currentenemyhealth);
                EASChecker = EAS;
            }
        }

    }
    private void OnTriggerEnter(Collider other) //偵測敵人本身有沒有跟弓箭產生碰撞
    {



        if (other.tag == "Bullet")      //如果碰到的物體tag為Bullet
        {


            tempDamage = other.GetComponent<bulletdestroy>().bullet_damage; //取得弓箭的傷害


            GetComponent<EnemyStat>().currentenemyhealth -= tempDamage;

            Debug.Log("EnemyHealth:" + GetComponent<EnemyStat>().currentenemyhealth);

            if (GetComponent<EnemyStat>().currentenemyhealth <= 0)  //如果敵人血量低於0就掰掰
            {
               
                if (Instantiateonce == false)
                {
                    int f = Random.Range(0, 100);
                    if (f >= 0)
                    {
                        Instantiate(PowerUp, transform.position, transform.rotation);
                        Instantiateonce = true;
                    }
                    else
                        Destroy(gameObject);
                }
                        
                    

                Destroy(gameObject);
            }
        }
        if (other.tag == "Explosion")
        {
            tempDamage = other.GetComponent<bulletdestroy>().Explosion_damage;
            GetComponent<EnemyStat>().currentenemyhealth -= tempDamage;

            Debug.Log("EnemyHealth:" + GetComponent<EnemyStat>().currentenemyhealth);

            if (GetComponent<EnemyStat>().currentenemyhealth <= 0)  //如果敵人血量低於0就掰掰
            {
                if (Instantiateonce == false)
                {
                    int f = Random.Range(0, 100);
                    if (f >= 0)
                    {
                        Instantiate(PowerUp, transform.position, transform.rotation);
                        Instantiateonce = true;
                    }
                    else
                        Destroy(gameObject);
                }



                Destroy(gameObject);
            }
        }

    }
}
        
    

    

