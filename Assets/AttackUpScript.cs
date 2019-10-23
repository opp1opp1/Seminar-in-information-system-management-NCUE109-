using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUpScript : MonoBehaviour {
    private GameObject Player;
    private float AttackUpPercent =0.1f;
    // Use this for initialization
    void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click()
    {
        Debug.Log("Button Clicked. Atk.");
        Player = GameObject.Find("Ashe");
        Player.GetComponent<PlayerStats>().currentAttackDamage += Player.GetComponent<PlayerStats>().basicAttackDamage * AttackUpPercent;
        Debug.Log(Player.GetComponent<PlayerStats>().currentAttackDamage);
    }
}
