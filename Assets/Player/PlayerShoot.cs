using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //public  float Ultmatecharge;
    private GameObject target;
    public GameObject arrow;

    private float CAS;
    private float CASChecker;
    private float CASChecker2;
    
    public float Multipleshoot; 
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Ashe");
        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
        CASChecker = CAS;
    }

    // Update is called once per frame
    void Update()
    {

        CASChecker -= Time.deltaTime;
        CASChecker2 -= Time.deltaTime;
        if (target.GetComponent<PlayerRotation>().enemychecker == true)
        {
            if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f && Multipleshoot == 1) //散射
            {            
                Instantiate(arrow, transform.position, transform.rotation);
                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                CASChecker = CAS;
            }
            else if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f && Multipleshoot == 2)    //連射
            {
                Instantiate(arrow, transform.position, transform.rotation);
                Instantiate(arrow, transform.position, transform.rotation);
                CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                CASChecker = CAS;
            }
            else if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f)  //單發
            {
                Instantiate(arrow, transform.position, transform.rotation);
                CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                CASChecker = CAS;           
            }

    }
    }


}

   
