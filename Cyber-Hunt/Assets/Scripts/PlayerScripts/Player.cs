using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	
	public int currentHealth;
	[SerializeField] private HealthBar healthBar;
	[SerializeField] private Rigidbody2D rb;
	private GameObject DeathScreen;
	private GameObject LevelUpMenu;
	[SerializeField] private TextMeshProUGUI hp;
	
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = globalVarables.playerMaxHealth;
		healthBar.SetMaxHealth(globalVarables.playerMaxHealth);
		DeathScreen = GameObject.FindWithTag("DeathMenu");
		LevelUpMenu = GameObject.FindWithTag("LevelUpMenu");
		DeathScreen.SetActive(false);
		LevelUpMenu.SetActive(false);
		hp.SetText(currentHealth.ToString());
	}
 


	// Update is called once per frame
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

