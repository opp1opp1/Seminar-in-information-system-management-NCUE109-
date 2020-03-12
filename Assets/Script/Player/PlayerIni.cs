using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerIni
{   
    
    public static float basicHealth ;
    public static float basicSheild = PlayerPrefs.GetFloat("Health");
    public static float currentHealth = PlayerPrefs.GetFloat("Health");
    public static float currentSheild = 0;
    public static float currentAttackDamage = PlayerPrefs.GetFloat("Attack");
    public static float currentAttackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
    public static float currentHealthLimit = PlayerPrefs.GetFloat("Health");

    public static bool Muitishot = false; //連續射擊
    public static bool MuitishotSecondChecker = false; //連續射擊的第二發判斷器
    public static bool FrontArrow = false; //齊射
    public static bool DiagonalArrow = false; //多重射擊
    public static bool IceArrow = false; //冰屬性
    public static bool FireArrow = false; //火屬性
    public static bool WindArrow = false; //風屬性
    public static bool EarthArrow = false; //土屬性




   
}

