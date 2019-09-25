using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour {
    
    void Start()
    {/*
        uiButton1.SetActive(false); //先將按鈕隱藏
        uiButton2.SetActive(false);
        uiButton3.SetActive(false);
        */
    }
    void OnTriggerEnter(Collider player)
    {/*
        if (player.gameObject.tag == "Player")  //當撞到Ashe後
        {
            clickAble = true;
            uiButton1.SetActive(true);
            uiButton2.SetActive(true);
            uiButton3.SetActive(true);
            
        }
        */
    }

    private void Update()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (clickAble == true)
                {
                    if (hit.transform != null)//點擊後要發生的事寫在底下
                    {
                        PrintName(hit.transform.gameObject);
                        Destroy(uiButton1);
                        Destroy(uiButton2);
                        Destroy(uiButton3);
                    }
                }
            }
        }*/
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }
    /*private GameObject player;
    private GameObject powerup;

    [SerializeField] private Button uiButton;

    void Start()
    {
        player = GameObject.Find("Ashe");
        powerup = GameObject.Find("powerup");
    }

    void OnCollisionEnter(Collider other)
    {
        if(other.CompareTag("Ashe"))
            uiButton.enabled = true;
    }

    void OnCollisionExit(Collider other)
    {
        if ()
            uiButton.enabled = false;
    }*/
}
