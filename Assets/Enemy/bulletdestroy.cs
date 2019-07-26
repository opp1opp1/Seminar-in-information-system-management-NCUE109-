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
        }
    }
}
