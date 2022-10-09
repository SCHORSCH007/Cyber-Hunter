using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public float level;
    public float currentXP;
    public float requiredXP;
    public GameObject mesh;
    public TextMeshProUGUI TextMesh;
    private GameObject LevelUpMenu;
    private float lerpTimer;
    
    [Header("UI")]

    public Image frontXpBar;

   
    private void Awake()
    {
        LevelUpMenu = GameObject.FindWithTag("LevelUpMenu");
        GameObject Level = GameObject.FindWithTag("Level");
        if(Level != null)
        {
          TextMesh =  Level.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("null");
        }
        if(mesh == null)
        {
            Debug.Log("nullmesh");
        }
    }
    void Start()
    {
        frontXpBar.fillAmount = currentXP / requiredXP;
        level = 1f;
       

        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            GainExperienceFlatRate(20);
        }
    }
    public void UpdateXpUI()
    {
        float xpFraction = currentXP / requiredXP;
        float FXP = frontXpBar.fillAmount;

        if(FXP < xpFraction)
        {
          frontXpBar.fillAmount = xpFraction;
        }
        if(currentXP== requiredXP)
        {
            frontXpBar.fillAmount = 0f;
            level = level +1;
            currentXP = 0f;
            LevelUpMenu.SetActive(true);
            Time.timeScale = 0;
            TextMesh.SetText(level.ToString());
            

        }
    }



    public void GainExperienceFlatRate(float xpGained)
    {
        currentXP += xpGained;
        
    }
}
