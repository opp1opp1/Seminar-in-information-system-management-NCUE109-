using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerCharacter : MonoBehaviour {

	public void CharacterScene()
    {
         SceneManager.LoadScene("CharacterScene");
        /*SceneManager.LoadScene("Arena");
        PlayerIni.basicHealth = PlayerPrefs.GetFloat("Health");
        PlayerIni.currentAttackDamage = PlayerPrefs.GetFloat("Attack");
        PlayerIni.currentAttackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
        PlayerIni.currentHealthLimit = PlayerPrefs.GetFloat("Health");*/
    }
}