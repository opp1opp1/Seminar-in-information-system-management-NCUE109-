using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerVictory : MonoBehaviour {

    private Transform p_transform;

	void Start()
    {
        p_transform = this.transform;
    }

    void Update()
    {
        if (p_transform.position.z > 11)
            SceneManager.LoadScene("MainScene");
    }
}
