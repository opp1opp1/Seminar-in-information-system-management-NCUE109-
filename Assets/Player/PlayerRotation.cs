using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
    
{
    // Vector3 targetPoint = Vector3.zero;     //鼠标点击的位置
    //private GameObject target;
    //獲取所有敵人
    public bool enemychecker = false;
    void Start()
    {

        // targetPoint = transform.position;

    }

    void Update()
    {
        /* if (Input.GetMouseButton(0))
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
         */


        transform.LookAt(OnGetEnemy());
    }
    public Transform OnGetEnemy()
    {
        //正在搜尋的半徑
        int radius = 1;
        //一步一步擴大搜索半徑,最大擴大到100
        while (radius < 100)
        {
            //球形射線檢測,得到半徑radius米範圍內所有的物件
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);
            //判斷檢測到的物件中有沒有Enemy
            if (cols.Length > 0)
                for (int i = 0; i < cols.Length; i++)
                    if (cols[i].tag.Equals("Enemy"))
                    {

                        enemychecker = true;
                       return cols[i].transform;
                    }
            //沒有檢測到Enemy,將檢測半徑擴大2米
            radius += 2;
        }
        enemychecker = false;
        return null;
    }
}