using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHealthLimit : MonoBehaviour {
    private GameObject Player;
    private float AddHealthLimitPercent = 0.25f;
    private float AddHealth;
    // Use this for initialization
    void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {

        Player = GameObject.Find("Ashe");

        AddHealth = Player.GetComponent<PlayerStats>().currentHealthLimit * AddHealthLimitPercent;
        PlayerIni.currentHealthLimit += AddHealth;
        PlayerIni.currentHealth += AddHealth;
        Player.GetComponent<PlayerStats>().currentHealthLimit = PlayerIni.currentHealthLimit;
        Player.GetComponent<PlayerStats>().currentHealth = PlayerIni.currentHealth;

        
    }
}
