
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private float requiredXP;
    [SerializeField] private GameObject mesh;
    [SerializeField] public TextMeshProUGUI skillpoints;

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
        frontXpBar.fillAmount = currentXP / requiredXP;
        level = 1f;
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
            frontXpBar.fillAmount = 0f;
            level = level + 1;
            IncreaseSkillPoints(1);
            currentXP = 0f;
            levelUpMenu.SetActive(true);
            UpdateLevelUpScreen();
            Time.timeScale = 0f;

            textMesh.SetText(level.ToString());
        }
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
