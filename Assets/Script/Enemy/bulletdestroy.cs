using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestroy : MonoBehaviour
{
    private GameObject target;
    private float lifeTime;
    public float maxTime = 3.0f;
    public float bullet_damage = 5.0f;
    public float sword_damage = 80.0f;
    public float slowTime = 2.0f;
    public float burnTime = 4.0f;
    public float stunTime = 0.5f;
    public GameObject Explosion;
    public GameObject BurnGround;
    public GameObject IceGround;
    public float ExplosionTime =0.5f;
    private float ExplosionTimeChecker =0;
    public float Explosion_damage;
    public float InstantiateGroundTime = 0.15f;
    public float InstantiateGroundTimer;
    private float targetShield;
    private float tempDamage;
    public GameObject Hitsound;
    // Use this for initialization
    void Start()
    {
        
        lifeTime = 0.0f;
        Explosion_damage = 0.25f * bullet_damage;
        if (this.gameObject.tag == "Explosion")
        {
            maxTime = 0.25f;
        }
        if (this.gameObject.tag == "BurnGround")        {
            maxTime = 0.75f;
        }
        if (this.gameObject.name == "FireWind_Arrow(Clone)")
        {
            InstantiateGroundTimer = InstantiateGroundTime;
            
        }
        if (this.gameObject.name == "Sword(Clone)")
        {
            maxTime = 0.25f;

        }
        if (this.gameObject.name == "Ashe_Arrow(Clone)")
        {
            bullet_damage = PlayerIni.currentAttackDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        ExplosionTimeChecker -= Time.deltaTime;
        if (lifeTime > maxTime)
        {
            Destroy(gameObject);
        }
        /*
        if (ExplosionTimeChecker < 0)
        {
            ExplosionTimeChecker = ExplosionTime;
        }
        */
        if (this.gameObject.name == "FireWind_Arrow(Clone)")
        {
            InstantiateGroundTimer -= Time.deltaTime;
            if (InstantiateGroundTimer <= 0)
            {
                Instantiate(BurnGround, transform.position+new Vector3(0,-0.0f,0), transform.rotation);
                InstantiateGroundTimer = InstantiateGroundTime;
            }
        }
        if (this.gameObject.name == "IceWind_Arrow(Clone)")
        {
            InstantiateGroundTimer -= Time.deltaTime;
            if (InstantiateGroundTimer <= 0)
            {
                Instantiate(IceGround, transform.position + new Vector3(0, -0.0f, 0), transform.rotation);
                InstantiateGroundTimer = InstantiateGroundTime;
            }
        }
    }

    //弓箭射到物體時消失
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy_1" || other.tag == "Enemy_2" || other.tag == "Enemy_3" || other.tag == "Enemy_4" || other.tag == "Enemy_5" || other.tag == "Enemy_6" || other.tag == "Enemy_7"|| other.tag == "Enemy_8")
        {
            if (this.gameObject.tag == "Bullet")
            {
                Instantiate(Hitsound, transform.position, transform.rotation);
                Destroy(gameObject);
                
                if (this.gameObject.name == "Ice_Arrow(Clone)")
                {
                    //other.GetComponent<EnemyBehavior>().agentspeed = other.GetComponent<EnemyBehavior>().agentspeed * 0.8f;
                    other.GetComponent<EnemyBehavior>().slowtimer = slowTime;
                }
                if (this.gameObject.name == "Fire_Arrow(Clone)")
                {
                    other.GetComponent<EnemyBehavior>().burntimer = burnTime;
                    other.GetComponent<EnemyBehavior>().burndamage = bullet_damage * 0.2f * 0.25f;
                }
                if (this.gameObject.name == "Wind_Arrow(Clone)")
                {
                    target = GameObject.Find("Ashe");
                    target.GetComponent<Playermove>().speeduptimer += 2.0f;
                }
                if (this.gameObject.name == "Earth_Arrow(Clone)")
                {
                    target = GameObject.Find("Ashe");
                    //target.GetComponent<PlayerStats>().currentSheild += 7.5f;
                    PlayerIni.currentSheild+= 10f;
                }
                if (this.gameObject.name == "Stun_Arrow(Clone)")
                {
                    other.GetComponent<EnemyBehavior>().stuntimer = stunTime;
                }
                if (this.gameObject.name == "Explosion_Arrow(Clone)")
                {
                    Instantiate(Explosion, transform.position, transform.rotation);
                }
            }

        }
        if (this.gameObject.name == "Enemy2bullet(Clone)" || this.gameObject.name == "Enemy4bullet(Clone)" || this.gameObject.name == "Enemy8bullet(Clone)")
        {
            if (other.gameObject.tag == "Player")
            {
                target = GameObject.Find("Ashe");
                if (target.GetComponent<PlayerStats>().itisinvincinble != true)//如果沒有無敵的話
                {
                    Debug.Log("reduce damage!");
                    targetShield = target.GetComponent<PlayerStats>().currentSheild;
                    if (target.GetComponent<PlayerStats>().reducedamage == true)//檢查是否有減傷
                    {

                        tempDamage = bullet_damage * 0.8f;
                        if (targetShield >= tempDamage)//檢查護盾是不是可以擋下傷害
                        {
                            targetShield -= tempDamage;
                            Debug.Log("bullet block by shield");
                            target.GetComponent<PlayerStats>().currentSheild = targetShield;
                        }
                        else
                        {
                            tempDamage -= targetShield;
                            target.GetComponent<PlayerStats>().currentSheild = 0;
                            if (tempDamage > 0)
                            {
                                /*targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                targethealth -= tempDamage;*/
                                Debug.Log("hit by bullet");
                                PlayerIni.currentHealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;
                            }
                        }
                    }
                    else
                    {
                        if (targetShield >= bullet_damage)
                        {
                            Debug.Log("bullet block by shield");
                            targetShield -= bullet_damage;
                            target.GetComponent<PlayerStats>().currentSheild = targetShield;
                        }
                        else if (targetShield < bullet_damage)
                        {
                            tempDamage = bullet_damage;
                            tempDamage -= targetShield;
                            target.GetComponent<PlayerStats>().currentSheild = 0;
                        }
                        if (tempDamage > 0)
                        {
                            Debug.Log("hit by bullet");
                            /*targethealth = target.GetComponent<PlayerStats>().currentHealth;
                            targethealth -= tempDamage;*/
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
        }
        if (this.gameObject.name == "Sword(Clone)")
        {
            if (other.gameObject.tag == "Player")
            {
                target = GameObject.Find("Ashe");
                if (target.GetComponent<PlayerStats>().itisinvincinble != true)//如果沒有無敵的話
                {
                    Debug.Log("reduce damage!");
                    targetShield = target.GetComponent<PlayerStats>().currentSheild;
                    if (target.GetComponent<PlayerStats>().reducedamage == true)//檢查是否有減傷
                    {

                        tempDamage = sword_damage * 0.8f;
                        if (targetShield >= tempDamage)//檢查護盾是不是可以擋下傷害
                        {
                            targetShield -= tempDamage;
                            Debug.Log("bullet block by shield");
                            target.GetComponent<PlayerStats>().currentSheild = targetShield;
                        }
                        else
                        {
                            tempDamage -= targetShield;
                            target.GetComponent<PlayerStats>().currentSheild = 0;
                            if (tempDamage > 0)
                            {
                                /*targethealth = target.GetComponent<PlayerStats>().currentHealth;
                                targethealth -= tempDamage;*/
                                Debug.Log("hit by Sword");
                                PlayerIni.currentHealth -= tempDamage;
                                target.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;
                            }
                        }
                    }
                    else
                    {
                        if (targetShield >= sword_damage)
                        {
                            Debug.Log("Sword block by shield");
                            targetShield -= sword_damage;
                            target.GetComponent<PlayerStats>().currentSheild = targetShield;
                        }
                        else if (targetShield < sword_damage)
                        {
                            tempDamage = sword_damage;
                            tempDamage -= targetShield;
                            target.GetComponent<PlayerStats>().currentSheild = 0;
                        }
                        if (tempDamage > 0)
                        {
                            Debug.Log("hit by Sword");
                            /*targethealth = target.GetComponent<PlayerStats>().currentHealth;
                            targethealth -= tempDamage;*/
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
        }
        if (other.tag == "Wall"&& (this.gameObject.name != "Explosion"|| this.gameObject.tag != "BurnGround"|| this.gameObject.tag != "IceGround"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (this.gameObject.name == "Explosion")
        {
            if (ExplosionTimeChecker <= 0)
            {
                
                ExplosionTimeChecker = ExplosionTime;

            }
            
        }
        if (this.gameObject.tag == "BurnGround")
        {
            if (collider.tag == "Enemy_1" || collider.tag == "Enemy_2" || collider.tag == "Enemy_3" || collider.tag == "Enemy_4" || collider.tag == "Enemy_5")
            {
                Debug.Log("Hit by BurnGround");
                collider.GetComponent<EnemyBehavior>().burntimer += collider.GetComponent<EnemyStat>().BurnGroundTime;
                collider.GetComponent<EnemyBehavior>().burndamage = collider.GetComponent<EnemyStat>().currentenemyhealth * 0.1f;
            }
        }
        if (this.gameObject.tag == "IceGround")
        {
            if (collider.tag == "Enemy_1" || collider.tag == "Enemy_2" || collider.tag == "Enemy_3" || collider.tag == "Enemy_4" || collider.tag == "Enemy_5")
            {
                Debug.Log("Hit by IceGround");
                collider.GetComponent<EnemyBehavior>().slowtimer += collider.GetComponent<EnemyStat>().IceGroundTime;
                
            }
        }
       
        }
    }

