using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerCharacter : MonoBehaviour {

	public void CharacterScene()
    {
        SceneManager.LoadScene("CharacterScene");
    }
}