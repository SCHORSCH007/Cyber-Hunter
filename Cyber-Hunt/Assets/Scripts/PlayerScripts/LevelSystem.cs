
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private float requiredXP;
    [SerializeField] private float vorFaktorXpfunction;
    [SerializeField] private float AdditionskonstXpFunction;
    [SerializeField] private GameObject mesh;
    [SerializeField] public TextMeshProUGUI skillpoints;
    [SerializeField] private GameObject LevelUpWings;

    private TextMeshProUGUI textMesh;
    private float level;
    private float currentXP;
    private GameObject levelUpMenu;

    [Header("UI")]
    [SerializeField] private Image frontXpBar;

    private void Awake()
    {
        
        levelUpMenu = GameObject.FindWithTag("LevelUpMenu");
        GameObject level = GameObject.FindWithTag("Level");
        if (level != null)
        {
            textMesh = level.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("null");
        }
        if (mesh == null)
        {
            Debug.Log("nullmesh");
        }
    }

    void Start()
    {
        level = 1f;
        calcNewRequiredXP();
        frontXpBar.fillAmount = currentXP / requiredXP;
        
    }

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
        float fXP = frontXpBar.fillAmount;

        if (fXP < xpFraction)
        {
            frontXpBar.fillAmount = xpFraction;
        }
        if (currentXP >= requiredXP)
        {
            calcNewRequiredXP();
            frontXpBar.fillAmount = 0f;
            level = level + 1;
            IncreaseSkillPoints(1);
            currentXP = 0f;
            LevelUpWings.SetActive(true);            
            UpdateLevelUpScreen();
            textMesh.SetText(level.ToString());
        }
    }

    public void calcNewRequiredXP()
    {
        float current = level * level;
        current = current * vorFaktorXpfunction;
        current = current + AdditionskonstXpFunction;
        requiredXP = current;
    }
    
    private void IncreaseSkillPoints(int amount)
    {
        globalVarables.SkillPoints += amount;
        skillpoints.SetText(globalVarables.SkillPoints.ToString());
    }
    private void UpdateLevelUpScreen()
    {
        UI_SkillTree tree = levelUpMenu.GetComponent<UI_SkillTree>();
        tree.UpdateVisuals();
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXP += xpGained;
    }

}
