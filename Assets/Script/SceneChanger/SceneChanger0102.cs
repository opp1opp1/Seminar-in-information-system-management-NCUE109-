using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger0102 : MonoBehaviour {

    private Transform p_transform;
    
    void Start()
    {
        p_transform = this.transform;
    }

	void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage0101")
        {
            if (p_transform.position.z > 13)
            {
                SceneManager.LoadScene("Stage0102");
                //PlayerIni.basicHealth = GetComponent<PlayerStats>().basicHealth;
                //PlayerIni.currentHealth = GetComponent<PlayerStats>().currentHealth;
               // GetComponent<Healthbar>().maxHP = GetComponent<PlayerStats>().basicHealth;
                //GetComponent<Healthbar>().currentHP = GetComponent<PlayerStats>().currentHealth;
                    }
        }
        else if (SceneManager.GetActiveScene().name == "Stage0102")
        {
            if (p_transform.position.z > 13)
                SceneManager.LoadScene("Stage0103");
        }
        else if (SceneManager.GetActiveScene().name == "Stage0103")
        {
            if (p_transform.position.z > 13)
                SceneManager.LoadScene("Stage0104");
        }
        else if (SceneManager.GetActiveScene().name == "Stage0104")
        {
            if (p_transform.position.z > 13)
                SceneManager.LoadScene("Stage0105");
        }
        else if (SceneManager.GetActiveScene().name == "Stage0105")
        {
            if (p_transform.position.z > 13)
                SceneManager.LoadScene("Stage0106");
        }
    }
}
