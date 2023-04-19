
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

        Maleware,

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

        MovementSpeed1,
        MovementSpeed2,
        MovementSpeed3,


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
            if (IsSkillUnlocked(skillRequirement)&& GetSkillCost(skillType) <= globalVarables.SkillPoints)
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
            if (GetSkillCost(skillType) <= globalVarables.SkillPoints)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            //Health Requrements
            case SkillType.Health2: return SkillType.Health1; 
            case SkillType.Health3: return SkillType.Health2; 
            case SkillType.Health4: return SkillType.Health3; 
            case SkillType.Health5: return SkillType.Health4;

            //Damage Requirements
            case SkillType.OverallDamage2: return SkillType.OverallDamage1;
            case SkillType.OverallDamage3: return SkillType.OverallDamage2;
            case SkillType.OverallDamage4: return SkillType.OverallDamage3;
            case SkillType.OverallDamage5: return SkillType.OverallDamage4;
            case SkillType.OverallDamage6: return SkillType.OverallDamage5;

            case SkillType.MovementSpeed2: return SkillType.MovementSpeed1;
            case SkillType.MovementSpeed3: return SkillType.MovementSpeed2;

            default: return SkillType.None;
        }
    }
    public int GetSkillCost(SkillType skillType)
    {
        switch(skillType)
        {

            //Blade upgrade costs
            case SkillType.CyberBlade1: return 1;
            case SkillType.CyberBlade2: return 3;
            case SkillType.CyberBlade3: return 6;
            case SkillType.CyberBlade4: return 8;

            //Health upgrade costs
            case SkillType.Health1: return 1;
            case SkillType.Health2: return 3;
            case SkillType.Health3: return 5;
            case SkillType.Health4: return 7;
            case SkillType.Health5: return 8;

            //Damage upgrade costs
            case SkillType.OverallDamage1: return 1;
            case SkillType.OverallDamage2: return 3;
            case SkillType.OverallDamage3: return 4;
            case SkillType.OverallDamage4: return 5;
            case SkillType.OverallDamage5: return 5;
            case SkillType.OverallDamage6: return 6;

            case SkillType.MovementSpeed1: return 2;
            case SkillType.MovementSpeed2: return 4;
            case SkillType.MovementSpeed3: return 2;

            case SkillType.Shield: return 3;

            case SkillType.Maleware: return 3;

            default: return 0;
        }
    }
    public bool TryUnlockSkill(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequirement(skillType);

        if (CanUnlock(skillType)&&GetSkillCost(skillType) <= globalVarables.SkillPoints && !IsSkillUnlocked(skillType)) {
            UnlockSkill(skillType);
            globalVarables.SkillPoints -= GetSkillCost(skillType);
            return true;
        }
        else
        {
            return false;
        }
    }

}  
    
