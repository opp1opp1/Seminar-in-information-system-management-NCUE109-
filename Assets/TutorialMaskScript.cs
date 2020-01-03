using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMaskScript : MonoBehaviour {
    private int Showtime =0;
    private GameObject Mask;
    private GameObject MoveText;
    private GameObject StandshootText;
    private GameObject AttentionText;
    private GameObject stop_button;
    private GameObject Powerup_Text;
    private GameObject Congratulation_Text;
    private GameObject Congratulation_Text2;
    private GameObject ArrowS;
    private GameObject ClickAnyWayText;
  //  private GameObject dummy;
   // private float dummy_health;
    //private bool dummy_dead_already;
    

    // Use this for initialization
    void Start () {

        //dummy_dead_already = false;
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Mask = GameObject.Find("TutorialMask");
        MoveText = GameObject.Find("Move Text");
        StandshootText = GameObject.Find("Standshoot Text");
        AttentionText = GameObject.Find("Attention Text");
        stop_button = GameObject.Find("stop_button");
        Powerup_Text = GameObject.Find("PowerUp Text");
        ClickAnyWayText = GameObject.Find("Click Anywhere Text");
        ArrowS = GameObject.Find("ArrowS"); 
        //Congratulation_Text = GameObject.Find("Congratulation Text");
        //Congratulation_Text2 = GameObject.Find("Congratulation Text2");
        //dummy = GameObject.Find("Dummy");
        // dummy_health = dummy.GetComponent<EnemyStat>().currentenemyhealth;
        ArrowS.SetActive(false);
        stop_button.SetActive(false);
        StandshootText.SetActive(false);
        AttentionText.SetActive(false);
        Powerup_Text.SetActive(false);
       // Congratulation_Text.SetActive(false);
       // Congratulation_Text2.SetActive(false);
        stop_button.GetComponent<PauseScript>().pauseGame();

        
    }



    // Update is called once per frame
    void Update () {
        
       
       /*if (dummy_dead_already==false && !dummy )
        {
            Showtime = 100;

            Debug.Log(Showtime);

            Powerup_Text.SetActive(true);
            Mask.SetActive(true);
            Congratulation_Text.SetActive(true);
            
            dummy_dead_already = true;

            stop_button.GetComponent<PauseScript>().pauseGame();
        }*/
		
	}
   private void OnClick()
    {
        
        Debug.Log(Showtime);

        if (Showtime == 0)
        {
            MoveText.GetComponent<ShowChecker>().Showed = true;
            StandshootText.SetActive(true);
            AttentionText.SetActive(true);
            Showtime++;
        }
        else if (Showtime == 1)
        {
            ClickAnyWayText.GetComponent<Text>().text = ("點擊升級道具繼續!");
            StandshootText.SetActive(false);
            AttentionText.SetActive(false);
            stop_button.SetActive(true);
            Powerup_Text.SetActive(true);
            ArrowS.SetActive(true);
            Mask.SetActive(false);
            stop_button.GetComponent<PauseScript>().pauseGame();
            

            //Showtime++;
        }
       /* else if (Showtime == 100)
        {
            Congratulation_Text.SetActive(false);
            Congratulation_Text2.SetActive(true);
            Showtime++;
        }
        */

    }
}
