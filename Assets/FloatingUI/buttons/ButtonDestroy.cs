using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDestroy : MonoBehaviour {
    public GameObject[] Buttons;
    public GameObject gameFPanel;
    public bool stopme = true;

	// Use this for initialization
	void Start () {
        gameFPanel = GameObject.Find("FPanel");
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Buttons = GameObject.FindGameObjectsWithTag("UIButton");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnClick()
    {
        for (var i = 0; i < Buttons.Length; i++)
        {
            Destroy(Buttons[i]);            
        }
    }
}
