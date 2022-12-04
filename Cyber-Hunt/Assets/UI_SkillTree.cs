using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class UI_SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;
    private List<SkillButton> skillButtonList;
    private Manager m;
    [SerializeField] private Material locked;
    [SerializeField] private Material unlocked;
    [SerializeField] private Material normal;
    [SerializeField] private Button_UI[] _SkillObjects;
    private void Awake()
    {

        // Blades

        m = GameObject.FindWithTag("assets").GetComponent<Manager>();
        playerSkills = new PlayerSkills();

        _SkillObjects[0].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade1);
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade1))
            {
                m.SwordButtonActivated(1);
            }
            UpdateVisuals();
            Debug.Log("geht");
        };
        _SkillObjects[1].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade2);
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade2))
            {
                m.SwordButtonActivated(2); 
            }
            UpdateVisuals();
        };
        _SkillObjects[2].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade3);
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade3))
            {
                m.SwordButtonActivated(3);
            }
            UpdateVisuals();
        };
        _SkillObjects[3].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade4);
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade4))
            {
                m.SwordButtonActivated(4);
            }
            UpdateVisuals();
        };

        // Health

        _SkillObjects[4].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health1);
            UpdateVisuals();
        };
        _SkillObjects[5].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health2);
            UpdateVisuals();
        };
        _SkillObjects[6].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health3);
            UpdateVisuals();
        };
        _SkillObjects[7].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health4);
            UpdateVisuals();
        };
        _SkillObjects[8].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health5);
            UpdateVisuals();
        };

        // PlayerDamage

        _SkillObjects[9].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.OverallDamage1);
            UpdateVisuals();
        };
        _SkillObjects[10].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.OverallDamage2);
            UpdateVisuals();
        };
        _SkillObjects[11].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.OverallDamage3);
            UpdateVisuals();
        };
        _SkillObjects[12].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.OverallDamage4);
            UpdateVisuals();
        };
        _SkillObjects[13].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.OverallDamage5);
            UpdateVisuals();
        };
        _SkillObjects[14].GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.OverallDamage6);
            UpdateVisuals();
        };

        // Shield
        _SkillObjects[15].GetComponent<Button_UI>().ClickFunc = () =>
        {
            
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Shield) && playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Shield) == false)
            {
                playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Shield);
                m.ShieldEnabled();
            }
            UpdateVisuals();
        };




    }


    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        skillButtonList = new List<SkillButton>();
        skillButtonList.Add(new SkillButton(_SkillObjects[0], playerSkills, PlayerSkills.SkillType.CyberBlade1, locked, unlocked, normal, _SkillObjects[0].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[1], playerSkills, PlayerSkills.SkillType.CyberBlade2, locked, unlocked, normal, _SkillObjects[1].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[2], playerSkills, PlayerSkills.SkillType.CyberBlade3, locked, unlocked, normal, _SkillObjects[2].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[3], playerSkills, PlayerSkills.SkillType.CyberBlade4, locked, unlocked, normal, _SkillObjects[3].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[4], playerSkills, PlayerSkills.SkillType.Health1, locked, unlocked, normal, _SkillObjects[4].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[5], playerSkills, PlayerSkills.SkillType.Health2, locked, unlocked, normal, _SkillObjects[5].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[6], playerSkills, PlayerSkills.SkillType.Health3, locked, unlocked, normal, _SkillObjects[6].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[7], playerSkills, PlayerSkills.SkillType.Health4, locked, unlocked, normal, _SkillObjects[7].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[8], playerSkills, PlayerSkills.SkillType.Health5, locked, unlocked, normal,_SkillObjects[8].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[9], playerSkills, PlayerSkills.SkillType.OverallDamage1, locked, unlocked, normal, _SkillObjects[9].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[10], playerSkills, PlayerSkills.SkillType.OverallDamage2, locked, unlocked, normal, _SkillObjects[10].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[11], playerSkills, PlayerSkills.SkillType.OverallDamage3, locked, unlocked, normal, _SkillObjects[11].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[12], playerSkills, PlayerSkills.SkillType.OverallDamage4, locked, unlocked, normal, _SkillObjects[12].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[13], playerSkills, PlayerSkills.SkillType.OverallDamage5, locked, unlocked, normal, _SkillObjects[13].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[14], playerSkills, PlayerSkills.SkillType.OverallDamage6, locked, unlocked, normal, _SkillObjects[14].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[15], playerSkills, PlayerSkills.SkillType.Shield, locked, unlocked, normal, _SkillObjects[15].GetComponent<Image>()));
        this.playerSkills = playerSkills;
        UpdateVisuals(); 
    }

    private void UpdateVisuals()
    {
        foreach(SkillButton skillButton in skillButtonList)
        {
            skillButton.UpdateVisuals();
        }
       
    }


    private class SkillButton
    {
        private Button_UI UI;
        private Image image;
        private PlayerSkills playerSkills;
        private PlayerSkills.SkillType skillType;
        private Material locked;
        private Material unlocked;
        private Material normal;

        public SkillButton(Button_UI UI, PlayerSkills playerSkills, PlayerSkills.SkillType skillType,Material locked,Material unlocked, Material normal,Image image)
        {
            this.UI = UI;
            this.playerSkills = playerSkills;
            this.skillType = skillType;
            this.locked = locked;
            this.unlocked = unlocked;
            this.normal = normal;
            this.image = image;


            
               
            
        }


        public void UpdateVisuals()
        {
            if (playerSkills.IsSkillUnlocked(skillType))
            {
                image.material = unlocked;
            }
            else
            {
                if (playerSkills.CanUnlock(skillType))
                {
                    image.material = normal;
                }
                else
                {
                    image.material = locked;
                }
            }
        }
    }
}