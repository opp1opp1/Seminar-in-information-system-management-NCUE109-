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
        currentHealth = PlayerIni.currentHealth;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("MainScene");
            PlayerIni.currentHealth = PlayerIni.basicHealth;
            PlayerIni.currentSheild = PlayerIni.basicSheild;

            PlayerIni.Muitishot = false; //連續射擊
            PlayerIni.MuitishotSecondChecker = false; //連續射擊的第二發判斷器
            PlayerIni.FrontArrow = false; //齊射
            PlayerIni.DiagonalArrow = false; //多重射擊
            PlayerIni.IceArrow = false; //冰屬性
            PlayerIni.FireArrow = false; //冰屬性
            PlayerIni.WindArrow = false; //風屬性
            PlayerIni.EarthArrow = false; //土屬性


}
        
    }
    }
    
