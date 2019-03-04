using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour {
    public float damage_byplayer;
    public float current_health;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody> ();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            // a rigidbody tagged as "Bullet" hit the player       
            
            rb.AddForce(new Vector3(-col.gameObject.transform.rotation.x, -col.gameObject.transform.rotation.y, -col.gameObject.transform.rotation.z) * damage_byplayer* current_health);
            current_health += damage_byplayer;
            Destroy(col.gameObject);
        }
    }
}
