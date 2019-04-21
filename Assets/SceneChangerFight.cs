using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerFight : MonoBehaviour {

    public void FightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
}
