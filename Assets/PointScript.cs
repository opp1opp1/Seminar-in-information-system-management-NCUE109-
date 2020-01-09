using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointScript : MonoBehaviour {
    public float point;
    public float money;
    public float survivetime =5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "MainScene") 
        {
            money =PlayerPrefs.GetFloat("Money");
            point += money;
            PlayerPrefs.SetFloat("Money",  + point);
            Debug.Log(PlayerPrefs.GetFloat("Money"));
            point = 0;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        
            if (SceneManager.GetActiveScene().name == "Arena")
            {
            survivetime -= Time.deltaTime;
            if (survivetime <= 0)
            {
                point += 3;
                survivetime = 5f;
            }
            }
        
    }
}
