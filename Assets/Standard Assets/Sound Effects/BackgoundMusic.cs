using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgoundMusic : MonoBehaviour {
    AudioSource background;
    // Use this for initialization
    void Start () {
        background = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
    }

    private void OnClick()
    {
        background.mute = !background.mute;
    }
}
