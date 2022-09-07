using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVarables : MonoBehaviour
{
    //player

    public static int playerMaxHealth = 5;
    public static float increasingDamage;

    //Fähigkeiten
    public static int n = 5;
    public static string[] abilityNames = new string[n];

    public static bool[] abilityUnlocked = new bool[n];

    //Dash

    public static float cooldownDash;
    public static float strengthDash;

}
