using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public float basicAttackDamage = 5;
    public float basicAttackSpeed = 1.0f;
    public float basicHealth = 100;
    public float currentAttackDamage = 5;
    public float currentAttackSpeed = 1.0f;
    public float currentHealth = 100;
    public float currentSheild = 0;
    private GameObject bullet;
    private float bulletdamage;
    private float removedshieldtime = 0.5f;
    private float removedshieldtimer;
    public bool invincible = false;
    private float invincinbletime = 2.0f;
    public float invincinbletimer;
    public bool itisinvincinble;
    private float nextinvincinbletime =0.5f;
    // Use this for initialization
    void Start () {
        removedshieldtimer = removedshieldtime;
        
            }

    // Update is called once per frame
    void Update()
    {
        if (currentSheild > 0f)
        {
            removedshieldtimer -= Time.deltaTime;
            if (removedshieldtimer <= 0f)
            {
                if (currentSheild > basicHealth * 0.02f)
                {
                    currentSheild -= basicHealth * 0.02f;
                    Debug.Log("Sheild:" + currentSheild);
                }
                else
                {
                    currentSheild = 0f;
                    Debug.Log("Sheild:" + currentSheild);
                }
                removedshieldtimer = removedshieldtime;
            }
        }
        if (invincible == true)
        {
            if (nextinvincinbletime > 0f)
            {
                nextinvincinbletime -= Time.deltaTime;

            }
            else 
            {
                invincinbletimer = invincinbletime;
                nextinvincinbletime = 10f;
            }

            if (invincinbletimer > 0f) //無敵
            {
                invincinbletimer -= Time.deltaTime;
                itisinvincinble = true;
                
            }
            else //沒無敵
            {
                itisinvincinble = false;
            }
        }
    }
    

}
