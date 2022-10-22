using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelUpManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Button[] healthUpgrades;
    [SerializeField] private bool[] healthButtonsPressed;

    public void Start()
    {
        healthUpgrades = new Button[4];
        healthButtonsPressed = new bool[4];
    }
    public void IncreaseHP()
    {
      
        
           for (int i = 0; i < 4; i++)
        {
            if (!healthButtonsPressed[i])
            {
                healthButtonsPressed[i] = true;
                globalVarables.playerMaxHealth += 10;
                healthUpgrades[i].enabled = false;
                return;
            }
        } 
        
       
    }
 
}
