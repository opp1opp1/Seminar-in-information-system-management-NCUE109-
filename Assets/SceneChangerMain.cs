﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerMain : MonoBehaviour {

	public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
