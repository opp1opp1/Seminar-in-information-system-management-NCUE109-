using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDestroy : MonoBehaviour {
    public GameObject[] Buttons;
    public GameObject gameFPanel;
    public GameObject ash;

	// Use this for initialization
	void Start () {
        gameFPanel = GameObject.Find("FPanel");
        ash = GameObject.Find("Ashe");
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
            //gameFPanel.GetComponent<FButtonInstantiate0>().stop = true; //吃到powerup時則會出現panel
            //gameFPanel.SetActive(false);    //先設置FPanel隱藏
            //ResumeGame();
        }
        ResumeGame();
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        ash.GetComponent<FUIAppear>().isPaused = false;
    }
}
