using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class UI_SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;
    private Manager m;
    private void Awake()
    {
        m = GameObject.FindWithTag("assets").GetComponent<Manager>();
        GameObject.Find("Blade1").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.CyberBlade1);

            m.SwordButtonActivated(1);
        };
        GameObject.Find("Blade2").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.CyberBlade2);
            m.SwordButtonActivated(2);
        };
        GameObject.Find("Blade3").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.CyberBlade3);
            m.SwordButtonActivated(3);
        };
        GameObject.Find("Blade4").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.CyberBlade4);
            m.SwordButtonActivated(4);
        };
    }


    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
    }
}
