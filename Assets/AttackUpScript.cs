using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUpScript : MonoBehaviour {
    private GameObject Player;
    private float AttackUpPercent =0.25f;
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
        PlayerIni.currentAttackDamage += Player.GetComponent<PlayerStats>().basicAttackDamage * AttackUpPercent;
        Player.GetComponent<PlayerStats>().currentAttackDamage = PlayerIni.currentAttackDamage;
        
    
       
        Debug.Log(Player.GetComponent<PlayerStats>().currentAttackDamage +""+ Player.GetComponent<PlayerStats>().basicAttackDamage);
    }
}
