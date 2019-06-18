﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger0102 : MonoBehaviour {

    private Transform p_transform;
    
    void Start()
    {
        p_transform = this.transform;
    }

	void Update()
    {
        if (p_transform.position.z > 4)
            SceneManager.LoadScene("Stage0102");
    }
}
