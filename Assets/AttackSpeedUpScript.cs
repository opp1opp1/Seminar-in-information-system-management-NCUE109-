using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSpeedUpScript : MonoBehaviour {
    private GameObject Player;
    private float AttackSpeedUpPercent = 0.4f;
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
        PlayerIni.currentAttackSpeed += Player.GetComponent<PlayerStats>().basicAttackSpeed * AttackSpeedUpPercent;
        if (PlayerIni.currentAttackSpeed > 2.5f)
        {
            PlayerIni.currentAttackSpeed = 2.5f;
        }
        Player.GetComponent<PlayerStats>().currentAttackSpeed = PlayerIni.currentAttackSpeed;
        if (GameObject.Find("TutorialMask") == true)
        {
            GameObject.Find("TutorialMask").SetActive(false);
        }


        Debug.Log(Player.GetComponent<PlayerStats>().currentAttackSpeed + "" + Player.GetComponent<PlayerStats>().basicAttackSpeed);
    }
}
