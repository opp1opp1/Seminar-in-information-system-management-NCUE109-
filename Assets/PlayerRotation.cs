using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour

{
     Vector3 targetPoint = Vector3.zero;     //鼠标点击的位置
    public GameObject aiming_sprite;

    void Start()
    {

        targetPoint = transform.position;

    }

    void Update()
    {

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
                aiming_sprite.transform.LookAt(new Vector3(targetPoint.x, transform.position.y, targetPoint.z));
            }
        }
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {


                //点击位置坐标   
                targetPoint = hit.point;
                //转向  

                Instantiate(aiming_sprite, (this.gameObject.transform.position + new Vector3(0f, 0.1f, 0f)), this.gameObject.transform.rotation);

            }
        }
        
    }
    
    
  

}