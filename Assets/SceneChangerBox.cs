using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerBox : MonoBehaviour {

    public void BoxScene()
    {
        SceneManager.LoadScene("BoxScene");
    }
}
