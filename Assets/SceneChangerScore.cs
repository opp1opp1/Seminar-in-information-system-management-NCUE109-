using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScore : MonoBehaviour {

	public void ScoreScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
