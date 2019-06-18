using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    //public  float Ultmatecharge;
    private GameObject target;
    public GameObject arrow;
    private float CAS;
    private float CASChecker;
    // Use this for initialization
    void Start () {
         target = GameObject.Find("Ashe");
        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
        CASChecker =CAS;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        CASChecker -= Time.deltaTime;
        if (target.GetComponent<Playermove>().Characterismoving == false&& CASChecker <= 0f)
        {
            Instantiate(arrow,transform.position,transform.rotation);
            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
            CASChecker = CAS;
        }

    }
    
}
