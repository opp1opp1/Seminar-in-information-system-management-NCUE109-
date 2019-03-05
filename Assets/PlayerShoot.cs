using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject sphere;
    public float MaxCharge =3;
    private float CheckFiretime = 0;
    public float ShootRate =0.5f;
    public float ChargeTime = 1f;
    private float CheckChargetime = 0;
    public float Ultmatecharge = 25f;
    private float CheckUltmatetime;
    
    Quaternion leftRota1 = Quaternion.AngleAxis(-30, Vector3.forward);
    Quaternion RightRota1 = Quaternion.AngleAxis(30, Vector3.forward); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转30度
    Quaternion leftRota2 = Quaternion.AngleAxis(-45, Vector3.forward);
    Quaternion RightRota2 = Quaternion.AngleAxis(45, Vector3.forward); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转45度
    // Use this for initialization
    void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
        CheckFiretime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space)&& CheckFiretime > ShootRate && MaxCharge>=1)
        {
            Instantiate(sphere, (this.gameObject.transform.position + new Vector3( 0f,0f,0f)), this.gameObject.transform.rotation);
            sphere.gameObject.transform.rotation = this.gameObject.transform.rotation;
            
            MaxCharge -= 1;
            CheckFiretime = 0;
        }
        CheckChargetime += Time.deltaTime;
        if (CheckChargetime >= ChargeTime)
        {
            MaxCharge += 1;
            CheckChargetime = 0;
        }
        if (MaxCharge > 3)
        {
            MaxCharge = 3;
        }
        CheckUltmatetime += Time.deltaTime;
        if (CheckUltmatetime >= 1.0f) 
        {
            Ultmatecharge += 1;
            CheckUltmatetime = 0f;
        }
        if (Ultmatecharge > 100)
        {
            Ultmatecharge = 100;
        }
        if (Ultmatecharge < 0)
        {
            Ultmatecharge = 0;
        }
        if (Input.GetKeyUp(KeyCode.K) &&  Ultmatecharge >= 100)
        {
            for (int j = 0; j < 5; j++) //一次发射5颗子弹
            {
                
                switch (j)
                {
                    case 0:
                        Instantiate(sphere, (this.gameObject.transform.position + new Vector3(0f, 0f, 0f)), this.gameObject.transform.rotation);  //发射第一颗子弹，方向不需要进行旋转。参数为子弹运动方向与生成位置，函数实现未列出。
                        break;
                    case 1:
                        Instantiate(sphere, (this.gameObject.transform.position + new Vector3(0f, 0f, 0f)), this.gameObject.transform.rotation*leftRota1);
                        break;
                    case 2:
                        Instantiate(sphere, (this.gameObject.transform.position + new Vector3(0f, 0f, 0f)), this.gameObject.transform.rotation * leftRota2);
                        break;
                    case 3:
                        Instantiate(sphere, (this.gameObject.transform.position + new Vector3(0f, 0f, 0f)), this.gameObject.transform.rotation * RightRota1);
                        break;
                    case 4:
                        Instantiate(sphere, (this.gameObject.transform.position + new Vector3(0f, 0f, 0f)), this.gameObject.transform.rotation * RightRota2);
                        break;
                }
            }
            Ultmatecharge -= 100;
            
        }
    }
}
