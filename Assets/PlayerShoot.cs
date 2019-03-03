using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject sphere;
    public float Shoot_Pos;
    public float MaxCharge =3;
    private float CheckFiretime = 0;
    public float ShootRate =0.5f;
    public float ChargeTime = 1f;
    private float CheckChargetime = 0;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        CheckFiretime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space)&& CheckFiretime > ShootRate && MaxCharge>=1)
        {
            Instantiate(sphere, (this.gameObject.transform.position + new Vector3( Shoot_Pos,0f, 0f)), this.gameObject.transform.rotation);
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

    }
}
