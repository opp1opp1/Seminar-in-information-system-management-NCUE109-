using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRotation : MonoBehaviour {
    GameObject father_gameObject;   //宣告一個GameObject(用來放取得的子物件)。
    Vector3 targetPoint = Vector3.zero;     //鼠标点击的位置
    // Use this for initialization
    void Start () {
        father_gameObject = GameObject.Find("Ashe");
        gameObject.transform.parent = father_gameObject.transform;
        // 宣告的物件 = father物件(利用Find尋找)。
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

               
                //点击位置坐标   
                targetPoint = hit.point;
                //转向  
                transform.LookAt(new Vector3(targetPoint.x, transform.position.y, targetPoint.z));
                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
        }
    }
}
