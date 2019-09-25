using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //public  float Ultmatecharge;
    private GameObject target;
    public GameObject arrow;
    public GameObject IceArrowPrefab;
    public GameObject FireArrowPrefab;
    public GameObject WindArrowPrefab;
    public GameObject EarthArrowPrefab;
    public GameObject StunArrowPrefab;
    public GameObject ExplosionArrowPrefab;
    public GameObject FireWindArrowPrefab;
    public GameObject IceWindArrowPrefab;
    private float CAS; //目前功速 (Current Attack Speed)
    private float CASChecker; //功速計時器

    private bool Muitishot ; //連續射擊Z
    private bool MuitishotSecondChecker ; //連續射擊的第二發判斷器
    private bool FrontArrow ; //齊射
    private bool DiagonalArrow; //多重射擊
    private bool IceArrow; //冰屬性
    private bool FireArrow; //冰屬性
    private bool WindArrow; //風屬性
    private bool EarthArrow; //土屬性


    //public float Multipleshoot; 舊程式碼的判斷方式
    // Use this for initialization

    void Start()
    {
       
        target = GameObject.Find("Ashe");
        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
        CASChecker = 0.5f; //整場遊戲的第一發不須等待 0.5S是考慮載入

         Muitishot = PlayerIni.Muitishot; //連續射擊Z
         MuitishotSecondChecker = PlayerIni.MuitishotSecondChecker; //連續射擊的第二發判斷器
         FrontArrow = PlayerIni.FrontArrow; //齊射
         DiagonalArrow = PlayerIni.DiagonalArrow; //多重射擊
         IceArrow = PlayerIni.IceArrow; //冰屬性
         FireArrow = PlayerIni.FireArrow; //冰屬性
         WindArrow = PlayerIni.WindArrow; //風屬性
         EarthArrow = PlayerIni.EarthArrow; //土屬性


}

    // Update is called once per frame
    void Update()
    {

        CASChecker -= Time.deltaTime;

        if (target.GetComponent<PlayerRotation>().enemychecker == true) //判斷是否有敵人
        {
            /*  舊射擊程式碼
            if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f && Multipleshoot == 1) //散射
            {            
                Instantiate(arrow, transform.position, transform.rotation);
                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                CASChecker = CAS;
            }
            else if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f && Multipleshoot == 0)    //單發
            {
                Instantiate(arrow, transform.position, transform.rotation);
                
                CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                CASChecker = CAS;
            }
            else if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f && Multipleshoot == 2)  //連射
            {
                if (rapidshoot == false)
                { Instantiate(arrow, transform.position, transform.rotation);
                    CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                    CASChecker = CAS * 0.1f;
                    rapidshoot = true;
                }
                else if(rapidshoot == true)
                {
                    Instantiate(arrow, transform.position, transform.rotation);
                    CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                    CASChecker = CAS * 0.9f;
                    rapidshoot = false;
                }
                
            }
            else if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f && Multipleshoot == 3)    //齊射
                {
                    
                    Instantiate(arrow, transform.position+(transform.right*0.2f), transform.rotation);
                    Instantiate(arrow, transform.position+(transform.right*-0.2f) , transform.rotation);
                    CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                    CASChecker = CAS;
                }
            
    */



            if (target.GetComponent<Playermove>().Characterismoving == false && CASChecker <= 0f)//判斷腳色是否可以發射 是否處於靜止狀態
            {
                /* 無敵 
                 if (IceArrow && FireArrow == true) 
                {
                    target.GetComponent<PlayerStats>().invincible = true;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                */
                if (FireArrow && IceArrow == true) //火+冰 =爆炸傷害
                {
                    arrow = ExplosionArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (FireArrow && WindArrow == true) //火+風 =經過路徑造成傷害
                {
                    arrow = FireWindArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (IceArrow && WindArrow == true) //冰+風 =經過路徑造成傷害
                {
                    arrow = IceWindArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (FireArrow && EarthArrow == true) //火+土 =反彈傷害
                {
                    target.GetComponent<PlayerStats>().reflectdamage = true;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (WindArrow && EarthArrow == true) //風+土 =禁錮
                {
                    arrow = StunArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (IceArrow && EarthArrow == true) //冰+土 =減少傷害
                {
                    target.GetComponent<PlayerStats>().reducedamage = true;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (IceArrow == true) //判斷子彈是否為冰屬性
                {
                    arrow = IceArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }
                else if (FireArrow == true) //判斷子彈是否為火屬性
                {
                    arrow = FireArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有火連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }

                }
                else if (WindArrow == true) ////判斷子彈是否為風屬性
                {
                    arrow = WindArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有風連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }

                }
                else if (EarthArrow == true) //判斷子彈是否為土屬性
                {
                    arrow = EarthArrowPrefab;
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else//沒有土連射
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }

                }
                else //沒有屬性的話
                {
                    if (Muitishot == true) //判斷是否有獲得連續射擊
                    {
                        if (MuitishotSecondChecker == false) //判斷是否是第一次射擊
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.1f;
                            MuitishotSecondChecker = true;

                        }
                        else
                        {
                            if (FrontArrow == true) //齊射
                            {
                                Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                                Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                            }
                            else
                                Instantiate(arrow, transform.position, transform.rotation);
                            if (DiagonalArrow == true) //散射
                            {
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                                Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                            }
                            CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                            CASChecker = CAS * 0.9f;
                            MuitishotSecondChecker = false;
                        }
                    }
                    else
                    {
                        if (FrontArrow == true) //齊射
                        {
                            Instantiate(arrow, transform.position + (transform.right * 0.2f), transform.rotation);
                            Instantiate(arrow, transform.position + (transform.right * -0.2f), transform.rotation);
                        }
                        else
                            Instantiate(arrow, transform.position, transform.rotation);
                        if (DiagonalArrow == true) //散射
                        {
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(45, transform.up));
                            Instantiate(arrow, transform.position, transform.rotation * Quaternion.AngleAxis(-45, transform.up));
                        }
                        CAS = target.GetComponent<PlayerStats>().currentAttackSpeed;
                        CASChecker = CAS;
                    }
                }

                }
            }

        
        }

    }



   
