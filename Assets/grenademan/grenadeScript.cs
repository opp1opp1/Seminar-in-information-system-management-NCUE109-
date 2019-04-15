using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeScript : MonoBehaviour {

    public float timeDelay = 2f;
    float startTimer;

    public int damage = 10;
    public float explosiveForce = 20f;
    public float explosiveRadius = 15f;

	// Update is called once per frame
	void Update () {
        startTimer += Time.deltaTime;
            if(startTimer >= timeDelay){
                    Explode();
                }
		
	}

    void Explode(){
        Collider[] coll = Physics.OverlapSphere(transform.position, explosiveRadius);

        for(int i =0; i < coll.Length; i++){
            if (coll[i].gameObject.GetComponent<testDummy>())
            {
                coll[i].gameObject.GetComponent<testDummy>().TakeDamage(damage);
                coll[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
            }
        }
        //Destroy(gameObject);
    }
   
}
