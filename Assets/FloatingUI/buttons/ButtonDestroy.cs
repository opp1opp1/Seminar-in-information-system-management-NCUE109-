using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDestroy : MonoBehaviour {
    public GameObject[] Buttons;
    public GameObject gameFPanel;
    public GameObject ash;
    public GameObject stop_button;  //用來在選擇能力時將暫停鈕隱藏，避免選擇能力時觸碰到暫停鈕
    public int st;

    // Use this for initialization
    void Awake ()
    {
        //stop_button = GameObject.Find("stop_button");   //找到stop_button
        //Debug.Log("hi");
    }
    void Start () {
        gameFPanel = GameObject.Find("FPanel");
        ash = GameObject.Find("Ashe");
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Buttons = GameObject.FindGameObjectsWithTag("UIButton");
        stop_button = GameObject.Find("stop_button");
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
        Vector3 st = stop_button.transform.position;    //恢復顯示暫停鈕
        st = new Vector3(st.x + 1000, st.y, st.z);
        stop_button.transform.position = st;
    }
}
