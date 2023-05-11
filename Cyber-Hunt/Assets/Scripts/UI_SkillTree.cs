
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using System.Collections;

public class UI_SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;
    private LevelSystem levelSystem;
    private List<SkillButton> skillButtonList;
    private Manager m;
    [SerializeField] private Material locked;
    [SerializeField] private Material unlocked;
    [SerializeField] private Material normal;
    [SerializeField] private Button_UI[] _SkillObjects;
    [SerializeField] private GameObject[] HealthUpgradesOptical;
    [SerializeField] private GameObject[] SpeedUpgradesOptical;
    private void Awake()
    {

        // Blades

        m = GameObject.FindWithTag("assets").GetComponent<Manager>();
        playerSkills = new PlayerSkills();
        levelSystem = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();

        _SkillObjects[0].GetComponent<Button_UI>().ClickFunc = () =>
        {            
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade1))
            {
                m.SwordButtonActivated(1);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade1);
            UpdateVisuals();
        };
        _SkillObjects[1].GetComponent<Button_UI>().ClickFunc = () =>
        {                   
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade2))
            {
                m.SwordButtonActivated(2); 
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade2);
            UpdateVisuals();
        };
        _SkillObjects[2].GetComponent<Button_UI>().ClickFunc = () =>
        {          
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade3))
            {
                m.SwordButtonActivated(3);
            }
            UpdateVisuals();
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade3);
        };
        _SkillObjects[3].GetComponent<Button_UI>().ClickFunc = () =>
        {           
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.CyberBlade4))
            {
                m.SwordButtonActivated(4);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.CyberBlade4);
            UpdateVisuals();
        };

        // Health

        _SkillObjects[4].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Health1))
            {
                HealthUpgradesOptical[0].SetActive(true);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health1);
            UpdateVisuals();
        };
        _SkillObjects[5].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Health2))
            {
                HealthUpgradesOptical[1].SetActive(true);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health2);
            UpdateVisuals();
        };
        _SkillObjects[6].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Health3))
            {
                HealthUpgradesOptical[2].SetActive(true);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health3);
            UpdateVisuals();
        };
        _SkillObjects[7].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Health4))
            {
                HealthUpgradesOptical[3].SetActive(true);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health4);
            UpdateVisuals();
        };
        _SkillObjects[8].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Health5))
            {
                HealthUpgradesOptical[4].SetActive(true);
            }
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
                
                m.ShieldEnabled();
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Shield);
            UpdateVisuals();
        };
        _SkillObjects[20].GetComponent<Button_UI>().ClickFunc = () =>
        {

            if (playerSkills.CanUnlock(PlayerSkills.SkillType.ShieldHealth1) && !playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.ShieldHealth1))
            {

                m.ShieldHealthInc(10);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.ShieldHealth1);
            UpdateVisuals();
        };
        _SkillObjects[21].GetComponent<Button_UI>().ClickFunc = () =>
        {
            
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.ShieldHealth2) && !playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.ShieldHealth2))
            {

                m.ShieldHealthInc(10);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.ShieldHealth2);
            UpdateVisuals();
        };
        //Maleware

        _SkillObjects[16].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (!playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Maleware))
            {
                if (playerSkills.CanUnlock(PlayerSkills.SkillType.Maleware))
                {
                    m.MalewareEnabled();
                    playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Maleware);
                }
            }
            
            UpdateVisuals();
        };

        //Speed
        _SkillObjects[17].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.MovementSpeed1))
            {
                //Main Fire MK2
                SpeedUpgradesOptical[0].SetActive(true);
                //Main Fire MK1
                SpeedUpgradesOptical[4].SetActive(false);

            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.MovementSpeed1);
            UpdateVisuals();
        };
        _SkillObjects[18].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.MovementSpeed2))
            {
                //secondary Engine
                SpeedUpgradesOptical[1].SetActive(true);
                //secondary Engine fire
                SpeedUpgradesOptical[2].SetActive(true);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.MovementSpeed2);
            UpdateVisuals();
        };
        _SkillObjects[19].GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.MovementSpeed3))
            {
                //Secondary Fire MK2
                SpeedUpgradesOptical[3].SetActive(true);
                //Secondary Fire MK1
                SpeedUpgradesOptical[2].SetActive(false);
            }
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.MovementSpeed3);
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
        skillButtonList.Add(new SkillButton(_SkillObjects[16], playerSkills, PlayerSkills.SkillType.Maleware, locked, unlocked, normal, _SkillObjects[16].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[17], playerSkills, PlayerSkills.SkillType.MovementSpeed1, locked, unlocked, normal, _SkillObjects[17].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[18], playerSkills, PlayerSkills.SkillType.MovementSpeed2, locked, unlocked, normal, _SkillObjects[18].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[19], playerSkills, PlayerSkills.SkillType.MovementSpeed3, locked, unlocked, normal, _SkillObjects[19].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[20], playerSkills, PlayerSkills.SkillType.ShieldHealth1, locked, unlocked, normal, _SkillObjects[20].GetComponent<Image>()));
        skillButtonList.Add(new SkillButton(_SkillObjects[21], playerSkills, PlayerSkills.SkillType.ShieldHealth2, locked, unlocked, normal, _SkillObjects[21].GetComponent<Image>()));

        this.playerSkills = playerSkills;
        UpdateVisuals(); 
    }

    public void UpdateVisuals()
    {
        levelSystem.skillpoints.SetText(globalVarables.SkillPoints.ToString());
        foreach (SkillButton skillButton in skillButtonList)
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