using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
    public enum SkillType
    {
        CyberBlade1,
        CyberBlade2,
        CyberBlade3,
        CyberBlade4,
        CyberBladeDamage1,
        CyberBladeDamage2,
        CyberBladeDamage3,
        CyberBladeDamage4,

        Shield,

        Health1,
        Health2,
        Health3,
        Health4,
        Health5,

        OverallDamage1,
        OverallDamage2,
        OverallDamage3,
        OverallDamage4,
        OverallDamage5,
        OverallDamage6,


    }

    private List<SkillType> unlockedSkillTypeList;

    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
        }
    }
    
    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }
}