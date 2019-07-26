using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestroy : MonoBehaviour
{
    private GameObject target;
    private float lifeTime;
    public float maxTime = 3.0f;
    public float bullet_damage = 20.0f;
    public float slowTime = 2.0f;
    public float burnTime = 4.0f;
    public float stunTime = 0.5f;
    public GameObject Explosion;
    public float ExplosionTime =0.5f;
    private float ExplosionTimeChecker =0;
    public float Explosion_damage;

    // Use this for initialization
    void Start()
    {
        lifeTime = 0.0f;
        Explosion_damage = 0.25f * bullet_damage;
        if (this.gameObject.name == "Explosion")
        {
            maxTime = 0.5f;
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
    }

    //弓箭射到物體時消失
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy_1"||other.tag == "Enemy_2")
        {
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
                target.GetComponent<PlayerStats>().currentSheild += 5.0f;
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
    private void OnTriggerStay(Collider collider)
    {
        if (this.gameObject.name == "Explosion")
        {
            if (ExplosionTimeChecker <= 0)
            {

                ExplosionTimeChecker = ExplosionTime;
            }
            
        }
    }
}
