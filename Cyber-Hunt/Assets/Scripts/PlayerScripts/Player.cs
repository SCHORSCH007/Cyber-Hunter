using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	
	
	[SerializeField] private HealthBar healthBar;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private TextMeshProUGUI hp;
	private GameObject DeathScreen;
	private GameObject LevelUpMenu;
	private int currentHealth;
	private PlayerSkills playerSkills;


    // Start is called before the first frame update


    private void Awake()
    {
		playerSkills = new PlayerSkills();
		DeathScreen = GameObject.FindWithTag("DeathMenu");
		LevelUpMenu = GameObject.FindWithTag("LevelUpMenu");
		currentHealth = globalVarables.playerMaxHealth;
		playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
		globalVarables.Player = gameObject;
	}

	private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
       switch (e.skillType)
        {
			case PlayerSkills.SkillType.Health1:
				SetMaxHealth(120);
				break;
			case PlayerSkills.SkillType.Health2:
				SetMaxHealth(140);
				break;
			case PlayerSkills.SkillType.Health3:
				SetMaxHealth(160);
				break;
			case PlayerSkills.SkillType.Health4:
				SetMaxHealth(180);
				break;
			case PlayerSkills.SkillType.Health5:
				SetMaxHealth(200);
				break;
			case PlayerSkills.SkillType.OverallDamage1:
				AddOverallDamage(1);
				break;
			case PlayerSkills.SkillType.OverallDamage2:
				AddOverallDamage(1);
				break;
			case PlayerSkills.SkillType.OverallDamage3:
				AddOverallDamage(1);
				break;
			case PlayerSkills.SkillType.OverallDamage4:
				AddOverallDamage(1);
				break;
			case PlayerSkills.SkillType.OverallDamage5:
				AddOverallDamage(1);
				break;
			case PlayerSkills.SkillType.OverallDamage6:
				AddOverallDamage(1);
				break;

		}
    }
   
	void Start()
	{	
		healthBar.SetMaxHealth(globalVarables.playerMaxHealth);
		DeathScreen.SetActive(false);
		LevelUpMenu.SetActive(false);
		hp.SetText(currentHealth.ToString());
	}
 

	public PlayerSkills GetPlayerSkills()
    {
		return playerSkills;
    }
		

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		hp.SetText(currentHealth.ToString());

		if (currentHealth<= 0)
		{
			DeathScreen.SetActive(true);
			Time.timeScale = 0;
		}
	}
	public void heal(int heal)
    {
		if (currentHealth < globalVarables.playerMaxHealth - heal)
		{
			currentHealth = currentHealth + heal;
			healthBar.SetHealth(currentHealth);
			hp.SetText(currentHealth.ToString());
		}
        else
        {
			currentHealth = globalVarables.playerMaxHealth;
			healthBar.SetHealth(currentHealth);
			hp.SetText(currentHealth.ToString());

		}
	}

	private void SetMaxHealth (int maxHealth)
    {
		int cur = globalVarables.playerMaxHealth;
		globalVarables.playerMaxHealth = maxHealth;
		heal(maxHealth - cur);
		healthBar.SetMaxHealth(currentHealth);

	}

	private void AddOverallDamage (int percent)
    {
		globalVarables.increasingDamage += percent;
    }



	//checks if XP is in radius of the trigger collider 
    private void OnTriggerEnter2D(Collider2D collision)
	{
		XPcollect XP = collision.GetComponent<XPcollect>();
		if (XP != null)
		{
			XP.moveToPlayer = true;     
		}
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
		XPcollect XP = collision.GetComponent<XPcollect>();
		if (XP != null)
		{
			XP.moveToPlayer = false;
		}
	}
}

