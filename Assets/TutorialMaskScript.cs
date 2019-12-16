using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMaskScript : MonoBehaviour {
    private int Showtime =0;
    private GameObject Mask;
    private GameObject MoveText;
    private GameObject stop_button;
    // Use this for initialization
    void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Mask = GameObject.Find("TutorialMask");
        MoveText = GameObject.Find("Move Text");
        stop_button = GameObject.Find("stop_button");
        stop_button.SetActive(false);
        stop_button.GetComponent<PauseScript>().pauseGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   private void OnClick()
    {
        
        Debug.Log(Showtime);
        Mask.SetActive(false);
        stop_button.SetActive(true);
        if (Showtime == 0)
        {
            MoveText.GetComponent<ShowChecker>().Showed =true;
            Showtime =Showtime+ 1;
        }
        stop_button.GetComponent<PauseScript>().pauseGame();

    }
}
