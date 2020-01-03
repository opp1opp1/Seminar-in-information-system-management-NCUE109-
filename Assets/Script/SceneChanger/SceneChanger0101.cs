using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger0101 : MonoBehaviour {

    public void Stage0101()
    {
        if (PlayerPrefs.GetFloat("Tutotial") == 0)
        {
            SceneManager.LoadScene("StageFirstStage");
            PlayerPrefs.SetFloat("Tutotial", 1);
        }
        else
        {
            SceneManager.LoadScene("Stage0101");
        }
        
    }
}
