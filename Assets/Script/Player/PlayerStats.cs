using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float basicAttackDamage =20;
    public float basicAttackSpeed = 1.0f;
    public float basicHealth;
    public float basicSheild;
    public float currentHealthLimit = 100f;
    public float currentAttackDamage = 20;
    public float currentAttackSpeed = 1.0f;
    public float currentHealth;
    public float currentSheild = 0;
    private GameObject bullet;
    private float bulletdamage;
    private float removedshieldtime = 0.5f;
    private float removedshieldtimer;
    public bool invincible = false;
    private float invincinbletime = 2.0f;
    public float invincinbletimer;
    public bool itisinvincinble;
    private float nextinvincinbletime = 0.5f;
    public bool reflectdamage = false;
    public float reflectdamageratio = 0.75f;
    public bool reducedamage = false;
    public float reducedamageratio = 0.8f;
    // Use this for initialization
    void Start()
    {
        removedshieldtimer = removedshieldtime;
        basicHealth = PlayerIni.basicHealth;
        basicSheild = PlayerIni.basicSheild;
        currentHealth = PlayerIni.basicHealth;
        currentAttackDamage = PlayerIni.currentAttackDamage;
        currentAttackSpeed = PlayerIni.currentAttackSpeed;
        currentHealthLimit = PlayerIni.currentHealthLimit;
        //currentSheild = PlayerIni.currentSheild;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = PlayerIni.currentHealth;
        currentAttackDamage = PlayerIni.currentAttackDamage;
        currentAttackSpeed = PlayerIni.currentAttackSpeed;
        currentHealthLimit = PlayerIni.currentHealthLimit;
        currentSheild = PlayerIni.currentSheild;
        if (PlayerIni.currentSheild > 0f)
        {
            removedshieldtimer -= Time.deltaTime;
            if (removedshieldtimer <= 0f)
            {
                if (PlayerIni.currentSheild > basicHealth * 0.1f)
                {
                    PlayerIni.currentSheild -= basicHealth * 0.2f;
                    Debug.Log("Sheild:" + PlayerIni.currentSheild);
                }
                else
                {
                    PlayerIni.currentSheild = 0f;
                    Debug.Log("Sheild:" + PlayerIni.currentSheild);
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
