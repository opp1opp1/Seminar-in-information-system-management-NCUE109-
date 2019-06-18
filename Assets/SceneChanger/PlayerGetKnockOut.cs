using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGetKnockOut : MonoBehaviour {
    //private Transform m_transform;
    private float currentHealth;
    // Use this for initialization
    void Start () {
        //m_transform = this.transform;
    }
	
	// Update is called once per frame
	public void Update () {
        /*
        if (m_transform.position.y > 20 || m_transform.position.y < -20)
            Destroy(gameObject);

        SceneManager.LoadScene("ScoreScene");
        */
        currentHealth = GetComponent<PlayerStats>().currentHealth;
        if (currentHealth == 0)
            SceneManager.LoadScene("MainScene");
        }
    }
    
