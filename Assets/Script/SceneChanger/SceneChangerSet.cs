using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerSet : MonoBehaviour {

	public void SetScene()
    {
        SceneManager.LoadScene("SetScene");
    }
}
