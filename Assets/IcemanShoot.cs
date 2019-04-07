using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcemanShoot : MonoBehaviour {
    public GameObject sphere;
    public GameObject UltmateObject;
    public float MaxCharge =3;
    private float CheckFiretime = 0;
    public float ShootRate =0.5f;
    public float ChargeTime = 1f;
    private float CheckChargetime = 0;
    public float Ultmatecharge = 25f;
    private float CheckUltmatetime;
    
    Quaternion leftRota1 = Quaternion.AngleAxis(-30, Vector3.down);
    Quaternion RightRota1 = Quaternion.AngleAxis(30, Vector3.down); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转30度
    Quaternion leftRota2 = Quaternion.AngleAxis(-45, Vector3.down);
    Quaternion RightRota2 = Quaternion.AngleAxis(45, Vector3.down); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转45度
    // Use this for initialization
    void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
        CheckFiretime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space)&& CheckFiretime > ShootRate && MaxCharge>=1)
        {
            Instantiate(sphere, this.gameObject.transform.position + new Vector3( 0f,0f,0f), this.gameObject.transform.rotation);
            //sphere.gameObject.transform.rotation = this.gameObject.transform.rotation;
            
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
            Instantiate(UltmateObject, this.gameObject.transform.position+this.gameObject.transform.forward*2, this.gameObject.transform.rotation);
            Ultmatecharge -= 100;
            
        }
    }
}
