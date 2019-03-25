using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerLoad : MonoBehaviour {

	public void LoadScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
}
