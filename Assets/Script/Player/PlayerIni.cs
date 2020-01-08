using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerIni
{   
    
    public static float basicHealth ;
    public static float basicSheild = 100;
    public static float currentHealth = 100;
    public static float currentSheild = 0;
    public static float currentAttackDamage = PlayerPrefs.GetFloat("Attack");
    public static float currentAttackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
    public static float currentHealthLimit = 100;

    public static bool Muitishot = true; //連續射擊
    public static bool MuitishotSecondChecker = true; //連續射擊的第二發判斷器
    public static bool FrontArrow = true; //齊射
    public static bool DiagonalArrow = true; //多重射擊
    public static bool IceArrow = true; //冰屬性
    public static bool FireArrow = false; //冰屬性
    public static bool WindArrow = false; //風屬性
    public static bool EarthArrow = false; //土屬性




   
}

