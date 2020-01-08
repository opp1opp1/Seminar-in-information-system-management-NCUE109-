using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Enemy2_bullet;
    public GameObject Enemy3_Sword;
    public GameObject Enemy4_ball;
    private NavMeshAgent agent;
    private GameObject Player;
    //public float WakeUpDistance;
    //public float ColliderDamage;
    private GameObject target;
    private GameObject destroyobject;
    private GameObject arrow;
    public GameObject PowerUp;
    public GameObject PowerUpTutorial;
    private float targethealth;
    private float targetShield;
    public float EAS;
    private float EASChecker;
    public float agentspeed;
    private float slowagentspeed;
    public float slowtimer = 0f;
    public float burntimer = 0f;
    private float burncounter = 0f;
    public float burndamage;
    private float tempDamage;
    private float Freezetime;
    public float stuntimer = 0f;
    private bool Instantiateonce = false;
    public Transform emission;
    public GameObject XiangYu;
    public GameObject hand;
    private bool onlyshootonce;
    private float enemy6_teleport = 5.0f;
    private float enemy6_teleport_checker;
    public GameObject Enemy6_warning_square;
    public GameObject Enemy4_warning;
    public GameObject Enemy9_Sword;
    public GameObject little_enemy7;
    private float ColidCheckTime;
    private GameObject point;

    private float enemy7_health;
    private float enemy8_health;
    private bool Is_divided = false;

    // Use this for initialization
    void Start()
    {
        point = GameObject.Find("Point Counter");
        Player = GameObject.Find("Ashe");
        agent = GetComponent<NavMeshAgent>();
        //agentspeed = GetComponent<EnemyStat>().agentspeed;
        Debug.Log("Agentspeed:" + GetComponent<EnemyStat>().agentspeed);
        agentspeed = GetComponent<EnemyStat>().agentspeed;
        GetComponent<NavMeshAgent>().speed = agentspeed;
        Debug.Log("Agentspeed:" + agentspeed);
        EAS = GetComponent<EnemyStat>().enemyattackspeed;
        EASChecker = EAS;
        slowagentspeed = agentspeed * 0.75f;



    }
   
   
     void Awake()
    {
        if (this.gameObject.tag == "Enemy_3")
        {
            XiangYu = this.gameObject.transform.GetChild(2).gameObject;
        }
        else if (this.gameObject.tag == "Enemy_2")
        {
            hand = this.gameObject.transform.GetChild(2).gameObject;
        }
        else if (this.gameObject.tag == "Enemy_6")
        {
            enemy6_teleport_checker = enemy6_teleport;
        }
    }


    // Update is called once per frame
    void Update()
    {
        EASChecker -= Time.deltaTime;
        ColidCheckTime -= Time.deltaTime;
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
                hand.GetComponent<handanimation>().hand_animator.SetBool("Escaping", true);
                //Vector3 newPos = transform.position ;
                agent.SetDestination(newPos);
            }

            if (EASChecker <= 0)
            {
                hand.GetComponent<handanimation>().hand_animator.SetBool("Attacking", true);
                target = GameObject.Find("Ashe");
                transform.LookAt(target.transform.position, transform.up);
                Instantiate(Enemy2_bullet, transform.position, transform.rotation);
                EASChecker = EAS;
            }

        }
        else if (this.gameObject.tag == ("Enemy_3"))
        {
            target = GameObject.Find("Ashe");
            if (distance < this.GetComponent<EnemyStat>().AttackDistance)
            {
                if (EASChecker <= 0f)
                {
                    XiangYu.GetComponent<XiangYuAnimation>().XiangYu_animator.SetBool("Attacking", true);
                    onlyshootonce = true;
                    EASChecker = EAS;

                }


                //Instantiate(Enemy3_Sword,new Vector3(transform.position.x, 1, transform.position.z), transform.rotation);
                //Vector3.Lerp(transform.position, Player.transform.position, 0.5f)


            }


            if (onlyshootonce == true)
            {
                if (XiangYu.GetComponent<XiangYuAnimation>().AnimatorIsPlaying("Throw"))
                {

                    
                    Vector3 lookatposition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                    transform.LookAt(lookatposition, transform.up);
                    do
                    {
                        Instantiate(Enemy9_Sword, new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, 0.5f), 1f, Mathf.Lerp(transform.position.z, Player.transform.position.z, 0.5f)), transform.rotation);
                        EASChecker = EAS;
                        XiangYu.GetComponent<XiangYuAnimation>().XiangYu_animator.SetBool("Attacking", false);
                        onlyshootonce = false;
                    }
                    while (onlyshootonce == true);
                }
            }
            else if (distance < this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                
                Vector3 lookatposition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(lookatposition, transform.up);
                Vector3 newPos = Player.transform.position;
                //Vector3 newPos = transform.position ;
                agent.SetDestination(newPos);
            }

        }    
                
            
        
        else if (this.gameObject.tag == ("Enemy_4"))
        {
            if (distance < this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                //Vector3 newPos = transform.position ;
                agent.SetDestination(newPos);

                destroyobject = GameObject.Find("enemy4_warning(Clone)");
                Destroy(destroyobject);
                //Quaternion change_angle = Quaternion.Euler(0, 0, 90);

                target = GameObject.Find("Ashe");

                Vector3 lookatposition = new Vector3(target.transform.position.x, 0.1f, target.transform.position.z);
                transform.LookAt(lookatposition, transform.up);
                Instantiate(Enemy4_warning, lookatposition, transform.rotation, this.gameObject.transform);



            }

            if (EASChecker <= 0)
            {


                //Freeze(0.5f);

                target = GameObject.Find("Ashe");




                transform.LookAt(target.transform.position, transform.up);
                // transform.rotation = Quaternion.Slerp(transform.rotation, change_angle, 0.2f);
                //transform.position += new Vector3(0.0f, 3.0f, 0.0f);
               /* Vector3 dir1 = transform.position  +new Vector3(1.0f, 3.0f, 0.0f);
                Vector3 dir2 = transform.position  +new Vector3(0.0f, 3.0f, 0.0f);
                Vector3 dir3 = transform.position  +new Vector3(-1.0f, 3.0f, 0.0f);
                Vector3 dir4 = transform.position  +new Vector3(0.0f, 3.0f, 1.0f);
                Vector3 dir5 = transform.position  +new Vector3(0.0f, 3.0f, -1.0f);
                Vector3 dir6 = transform.position + new Vector3(1.0f, 1.5f, 0.0f);
                Vector3 dir7 = transform.position + new Vector3(0.0f, 1.5f, 0.0f);
                Vector3 dir8 = transform.position + new Vector3(-1.0f,1.5f, 0.0f);
                Vector3 dir9 = transform.position + new Vector3(0.0f, 1.5f, 1.0f);
                Vector3 dir10 = transform.position + new Vector3(0.0f, 1.5f, -1.0f);*/


                 Vector3 dir1 = transform.position + new Vector3(1.15f, 3.5f, 0.0f);
                Vector3 dir2 = transform.position + new Vector3(0.0f, 3.0f, 0.0f);
                Vector3 dir3 = transform.position + new Vector3(-1.15f, 3.5f, 0.0f);
                Vector3 dir4 = transform.position + new Vector3(0.0f, 3.5f, 1.15f);
                Vector3 dir5 = transform.position + new Vector3(0.0f, 3.5f, -1.15f);

                Vector3 dir6 = transform.position + new Vector3(1.0f, 2.0f, 0.0f);
                Vector3 dir7 = transform.position + new Vector3(0.0f, 1.5f, 0.0f);
                Vector3 dir8 = transform.position + new Vector3(-1.0f, 2.0f, 0.0f);
                Vector3 dir9 = transform.position + new Vector3(0.0f, 2.0f, 1.0f);
                Vector3 dir10 = transform.position + new Vector3(0.0f, 2.0f, -1.0f);

                /*Vector3 dir1 = transform.position;
                Vector3 dir2 = transform.position;
                Vector3 dir3 = transform.position;
                Vector3 dir4 = transform.position;
                Vector3 dir5 = transform.position;
                Vector3 dir6 = transform.position;
                Vector3 dir7 = transform.position;
                Vector3 dir8 = transform.position;
                Vector3 dir9 = transform.position;
                Vector3 dir10 = transform.position;*/

                Instantiate(Enemy4_ball, dir1, transform.rotation);
                Instantiate(Enemy4_ball, dir2, transform.rotation);
                Instantiate(Enemy4_ball, dir3, transform.rotation);
                Instantiate(Enemy4_ball, dir4, transform.rotation);
                Instantiate(Enemy4_ball, dir5, transform.rotation);
                Instantiate(Enemy4_ball, dir6, transform.rotation);
                Instantiate(Enemy4_ball, dir7, transform.rotation);
                Instantiate(Enemy4_ball, dir8, transform.rotation);
                Instantiate(Enemy4_ball, dir9, transform.rotation);
                Instantiate(Enemy4_ball, dir10, transform.rotation);

                EASChecker = EAS;

            }

        }
        else if (this.gameObject.tag == "Enemy_5")
        {
            if (distance <= this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                //Vector3 dirToPlayer = transform.position - Player.transform.position;
                //Vector3 newPos = transform.position + dirToPlayer;
                Vector3 newPos = Player.transform.position;
                agent.SetDestination(newPos);

            }
        }
        else if (this.gameObject.tag == ("Enemy_6"))
        {
            
            enemy6_teleport_checker -= Time.deltaTime;
            
            if (distance < this.GetComponent<EnemyStat>().AttackDistance)
            {
                if (EASChecker <= 0)
                {
                    target = GameObject.Find("Ashe");
                    Vector3 lookatposition = new Vector3(target.transform.position.x, 0.1f, target.transform.position.z);
                    transform.LookAt(lookatposition, transform.up);
                    Instantiate(Enemy6_warning_square, new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, 0.8f), 0.1f, Mathf.Lerp(transform.position.z, Player.transform.position.z, 0.8f)),transform.rotation,this.gameObject.transform);
                    //Instantiate(Enemy6_warning_square, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation, this.gameObject.transform);
                    Freeze(1.5f);
                    EASChecker = EAS;
                }
                else
                {
                    target = GameObject.Find("Ashe");
                    Vector3 lookatposition = new Vector3(target.transform.position.x, 0.5f, target.transform.position.z);
                    transform.LookAt(lookatposition, transform.up);
                    Vector3 newPos = Player.transform.position;
                    //Vector3 newPos = transform.position ;
                    agent.SetDestination(newPos);
                }
            }
            else if (distance < this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                if (enemy6_teleport_checker <= 0)
                {
                    target = GameObject.FindGameObjectWithTag("Enemy_6_transport_position");
                    agent.Warp(new Vector3(target.transform.position.x, 0.5f, target.transform.position.z));
                    enemy6_teleport_checker = enemy6_teleport;
                    target = GameObject.Find("Ashe");
                    EASChecker = 0.5f;
                }
                else 
                {
                    target = GameObject.Find("Ashe");
                    Vector3 lookatposition = new Vector3(target.transform.position.x, 0.5f, target.transform.position.z);
                    transform.LookAt(lookatposition, transform.up);
                    Vector3 newPos = Player.transform.position;
                    //Vector3 newPos = transform.position ;
                    agent.SetDestination(newPos);
                }
                
            }

            /* if (EASChecker <= 0)
             {

                 target = GameObject.Find("Ashe");d
                 transform.LookAt(target.transform.position, transform.up);
                 Instantiate(Enemy2_bullet, transform.position, transform.rotation);
                 EASChecker = EAS;
             }
             */
        }
        else if (this.gameObject.tag == ("Enemy_7"))
        {
            enemy7_health = GetComponent<EnemyStat>().currentenemyhealth;

            if (distance <= this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                Vector3 newPos = Player.transform.position;
                agent.SetDestination(newPos);
            }
            if(Is_divided==false && enemy7_health <= 40)
            {
                if (this.gameObject.name != ("Enemy7(Clone)"))
                {
                    Instantiate(little_enemy7, transform.position, transform.rotation);
                    Instantiate(little_enemy7, transform.position, transform.rotation);
                }


               /* Instantiate(little_enemy7, transform.position, transform.rotation);
                Instantiate(little_enemy7, transform.position, transform.rotation);*/
                

                Is_divided = true;
            }

            if (this.gameObject.name == ("Enemy7(Clone)"))
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Debug.Log("縮小2");

            }


        }
        else if (this.gameObject.tag == ("Enemy_8"))
        {
            enemy8_health = GetComponent<EnemyStat>().currentenemyhealth;

            if (distance <= this.GetComponent<EnemyStat>().WakeUpDistance)
            {
                Vector3 newPos = Player.transform.position;
                agent.SetDestination(newPos);
            }

            if (distance < this.GetComponent<EnemyStat>().AttackDistance) //進入近戰範圍
            {
                Debug.Log("近戰攻擊!");
                if (EASChecker <= 0)
                {

                    target = GameObject.Find("Ashe");
                    transform.LookAt(target.transform.position, transform.up);

                    // Instantiate(Enemy3_Sword, transform.position, transform.rotation);
                    Instantiate(Enemy3_Sword, new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, 0.5f), 1f, Mathf.Lerp(transform.position.z, Player.transform.position.z, 0.5f)), transform.rotation);
                    EASChecker = EAS;
                }
            }
            else //不在近戰範圍內就遠程散彈攻擊!
            {
                if (EASChecker <= 0)
                {

                    target = GameObject.Find("Ashe");
                    transform.LookAt(target.transform.position, transform.up);

                    Instantiate(Enemy2_bullet, transform.position, transform.rotation);
                    Instantiate(Enemy2_bullet, transform.position, transform.rotation * Quaternion.AngleAxis(10, transform.up));
                    Instantiate(Enemy2_bullet, transform.position, transform.rotation * Quaternion.AngleAxis(20, transform.up));
                    Instantiate(Enemy2_bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-10, transform.up));
                    Instantiate(Enemy2_bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-20, transform.up));


                    EASChecker = EAS;
                    EASChecker = EAS;
                    EASChecker = EAS;
                    EASChecker = EAS;
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
        if (burntimer > 0f)
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
        if (gameObject.tag == "Enemy_1"|| gameObject.tag == "Enemy_2"|| gameObject.tag == "Enemy_3"|| gameObject.tag == "Enemy_4"|| gameObject.tag == "Enemy_5" || gameObject.tag == "Enemy_6" || gameObject.tag == "Enemy_7" || gameObject.tag == "Enemy_8 ")
        {
            if (other.name == "Ashe")
            {
                target = GameObject.Find("Ashe");
                if (ColidCheckTime <= 0)
                {

                    ColidCheckTime = 0.5f;
                    if (target.GetComponent<PlayerStats>().itisinvincinble != true)
                    {
                        Debug.Log("沒有無敵");
                        targetShield = PlayerIni.currentSheild;
                        if (target.GetComponent<PlayerStats>().reducedamage == true)
                        {
                            Debug.Log("有減傷");
                            tempDamage = GetComponent<EnemyStat>().ColliderDamage * target.GetComponent<PlayerStats>().reducedamageratio;
                            if (targetShield >= tempDamage)
                            {
                                Debug.Log("護盾擋住了(有減傷)");
                                targetShield -= tempDamage;
                                target.GetComponent<PlayerStats>().currentSheild = targetShield;
                            }
                            else
                            {
                                tempDamage -= targetShield;
                                target.GetComponent<PlayerStats>().currentSheild = 0;
                                if (tempDamage > 0)
                                {
                                    Debug.Log("承受傷害!(有減傷)");
                                    /*targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                    targethealth -= tempDamage;*/
                                    PlayerIni.currentHealth -= tempDamage;
                                    target.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("沒有減傷");
                            tempDamage = GetComponent<EnemyStat>().ColliderDamage ;
                            if (targetShield >= tempDamage)
                            {
                                Debug.Log("護盾擋住了");
                                PlayerIni.currentSheild -= tempDamage;
                                target.GetComponent<PlayerStats>().currentSheild = PlayerIni.currentSheild;
                                //targetShield -= GetComponent<EnemyStat>().ColliderDamage;
                                //target.GetComponent<PlayerStats>().currentSheild = targetShield;
                            }
                            else if (targetShield < tempDamage)
                            {
                                Debug.Log("承受傷害!(護盾承受階段)");
                                PlayerIni.currentSheild -= tempDamage;
                                target.GetComponent<PlayerStats>().currentSheild = PlayerIni.currentSheild;
                                PlayerIni.currentSheild = 0;

                                /*tempDamage = GetComponent<EnemyStat>().ColliderDamage;
                                tempDamage -= targetShield;
                                target.GetComponent<PlayerStats>().currentSheild = 0;*/
                            }
                            if (PlayerIni.currentSheild <= 0)
                            {
                                Debug.Log("承受傷害!");
                                /* targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                 targethealth -= tempDamage;*/
                                PlayerIni.currentHealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;
                            }
                        }
                    }
                    if (target.GetComponent<PlayerStats>().reflectdamage == true)
                    {
                        int n = 0;
                        do
                        {
                            GetComponent<EnemyStat>().currentenemyhealth -= GetComponent<EnemyStat>().ColliderDamage * target.GetComponent<PlayerStats>().reflectdamageratio;
                            if (GetComponent<EnemyStat>().currentenemyhealth <= 0)  //如果敵人血量低於0就掰掰
                            {

                                if (Instantiateonce == false)
                                {
                                    int f = Random.Range(0, 100);
                                    if (this.gameObject.name != "Dummy")
                                    {
                                        if (f >= 40)
                                        {
                                            Instantiate(PowerUp, transform.position, transform.rotation);
                                            Instantiateonce = true;
                                        }
                                        else
                                        {
                                            Destroy(gameObject);
                                        }
                                    }
                                    else
                                    {
                                        Instantiate(PowerUpTutorial, transform.position, transform.rotation);
                                        Instantiateonce = true;
                                        Destroy(gameObject);
                                    }
                                }



                                Destroy(gameObject);
                            }
                        } while (n > 1);
                    }
                    else
                    {
                        Debug.Log("invincinble");
                    }
                }
                
                Debug.Log("Health:" + target.GetComponent<PlayerStats>().currentHealth + "Sheild:" + target.GetComponent<PlayerStats>().currentSheild + "EnemyHealth" + GetComponent<EnemyStat>().currentenemyhealth);
                
            }
        }
        /*
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
                                    //targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                    //targethealth -= tempDamage;
                                    
                                    PlayerIni.currentHealth -= tempDamage;
                                    target.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;
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
                                //targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                //targethealth -= tempDamage;
                                PlayerIni.currentHealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;

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
    */
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
                    if (this.gameObject.name != "Dummy")
                    {
                        if (f >= 40)
                        {
                            Instantiate(PowerUp, transform.position, transform.rotation);
                            Instantiateonce = true;
                        }
                        else
                        {
                            Destroy(gameObject);
                        }
                    }
                    else
                    {
                        Instantiate(PowerUpTutorial, transform.position, transform.rotation);
                        Instantiateonce = true;
                        Destroy(gameObject);
                    }
                }



                Destroy(gameObject);
            }
            GetComponent<ParticleSystem>().Play();
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
    private void Freeze(float time)
    {
        time -= Time.deltaTime;

        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        if (time <= 0f)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
    void OnDestroy()
    {
        int f = Random.Range(0, 3);
        if (this.gameObject.tag == "Enemy_1" && this.gameObject.name != "Dummy" || this.gameObject.tag == "Enemy_2"|| this.gameObject.tag == "Enemy_5")
        {
            point.GetComponent<PointScript>().point += f * 1;
        }
        else if (this.gameObject.tag == "Enemy_4" || this.gameObject.tag == "Enemy_6" )
        {
            point.GetComponent<PointScript>().point += f * 2;
        }
        else if (this.gameObject.tag == "Enemy_3")
        {
            point.GetComponent<PointScript>().point += f * 5;
        }
    }
}





