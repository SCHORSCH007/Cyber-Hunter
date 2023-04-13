using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVarables : MonoBehaviour
{
    //player

    public static int playerMaxHealth = 100;
    public static int increasingDamage = 1;
    public static int SkillPoints = 0;
    public static int kills = 0;
    public static bool Bossfight = false;
    public static GameObject Player;

    //Fähigkeiten
    public static int n = 5;

    //Dash

    public static float cooldownDash;
    public static float strengthDash;

}
