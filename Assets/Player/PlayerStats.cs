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
    }
    

}
