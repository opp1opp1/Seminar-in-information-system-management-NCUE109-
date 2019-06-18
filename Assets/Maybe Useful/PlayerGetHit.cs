using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerGetHit : MonoBehaviour {
    public float current_health ;
    private Rigidbody rb;
    private float damage_count;
    private GameObject target;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ashe_Arrow(Clone)")
        {
             float damage = other.GetComponent<bulletdestroy>().bullet_damage;
            damage_count = rb.mass * damage*current_health;
            if (damage_count <= 0)
            {
                damage_count = 20;
            }
            rb.AddForce(new Vector3(this.transform.position.x - other.transform.position.x, 1f, this.transform.position.z - other.transform.position.z) * damage_count);
            current_health += damage    ;
            Destroy(other.gameObject);
            target = GameObject.Find("Ashe");
             target.GetComponent<PlayerShoot>().Ultmatecharge+=5f;
         
        }
        if (other.name == "IceMan_IceBall(Clone)")
        {
            float damage = other.GetComponent<bulletdestroy>().bullet_damage;
            damage_count = rb.mass * damage * current_health;
            if (damage_count <= 0)
            {
                damage_count = 20;
            }
            rb.AddForce(new Vector3(this.transform.position.x - other.transform.position.x, 1f, this.transform.position.z - other.transform.position.z) * damage_count);
            current_health += damage;
            Destroy(other.gameObject);
            this.GetComponent<PlayerDebuff>().Slowtime += 2f;
            target = GameObject.Find("IceMan");
            target.GetComponent<PlayerShoot>().Ultmatecharge += 5f;

        }
        if (other.name == "ICEMOUNTAIN(Clone)")
        {
            float damage = other.GetComponent<bulletdestroy>().bullet_damage;
            //damage_count = rb.mass * damage * current_health;
            //if (damage_count <= 0)
            //{
               // damage_count = 20;
            //}
            //rb.AddForce(new Vector3(this.transform.position.x - other.transform.position.x, 1f, this.transform.position.z - other.transform.position.z) * damage_count);
            current_health += damage;
            //Destroy(other.gameObject);
            this.GetComponent<PlayerDebuff>().Freezetime += 2f;
            target = GameObject.Find("IceMan");
            target.GetComponent<PlayerShoot>().Ultmatecharge += 10f;

        }
    }
}
*/