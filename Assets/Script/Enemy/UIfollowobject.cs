using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfollowobject : MonoBehaviour
{
    public Text HPlable;
    public Image healthbarback;
    public Image healthbar;


    // Update is called once per frame
    void Update()
    {
        Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
        HPlable.transform.position = namePose +new Vector3 (60,20,0);
        healthbarback.transform.position = namePose;
        healthbar.transform.position = namePose;
    }
}