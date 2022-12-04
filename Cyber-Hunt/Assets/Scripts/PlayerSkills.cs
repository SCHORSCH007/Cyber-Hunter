
using System.Collections.Generic;
using System;

public class PlayerSkills
{
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;
    public class OnSkillUnlockedEventArgs : EventArgs
    {
        public SkillType skillType;
    }
    public enum SkillType
    {
        None,

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

    private void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
            OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
        }
    }

    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }

    public bool CanUnlock(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequirement(skillType);

        if (skillRequirement != SkillType.None)
        {
            if (IsSkillUnlocked(skillRequirement))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }



    public SkillType GetSkillRequirement(SkillType skillType)
    {
        switch (skillType)
        {
            //Cyber blade Requirements
            case SkillType.CyberBlade2: return SkillType.CyberBlade1;
            case SkillType.CyberBlade3: return SkillType.CyberBlade2; 
            case SkillType.CyberBlade4: return SkillType.CyberBlade3; 

            case SkillType.Health2: return SkillType.Health1; 
            case SkillType.Health3: return SkillType.Health2; 
            case SkillType.Health4: return SkillType.Health3; 
            case SkillType.Health5: return SkillType.Health4;

            case SkillType.OverallDamage2: return SkillType.OverallDamage1;
            case SkillType.OverallDamage3: return SkillType.OverallDamage2;
            case SkillType.OverallDamage4: return SkillType.OverallDamage3;
            case SkillType.OverallDamage5: return SkillType.OverallDamage4;
            case SkillType.OverallDamage6: return SkillType.OverallDamage5;

            default: return SkillType.None;
        }
    }
    public bool TryUnlockSkill(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequirement(skillType);

        if (CanUnlock(skillType)) {
            UnlockSkill(skillType);
            return true;
        }
        else
        {
            return false;
        }
    }
}  
    
