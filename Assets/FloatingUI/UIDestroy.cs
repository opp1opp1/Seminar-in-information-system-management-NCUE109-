using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDestroy : MonoBehaviour {
    
    public GameObject uiButton1, uiButton2, uiButton3;
    
    public bool clickAble = false;

    private void Update()
    {
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
                        Destroy(uiButton1);
                        Destroy(uiButton2);
                        Destroy(uiButton3);
                    }
                }
            }
        }
    }
}
