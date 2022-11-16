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
		currentHealth += heal;
		healthBar.SetHealth(currentHealth);
		hp.SetText(currentHealth.ToString());
	}

	private void SetMaxHealth (int maxHealth)
    {
		globalVarables.playerMaxHealth = maxHealth;
		healthBar.SetMaxHealth(currentHealth);
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

