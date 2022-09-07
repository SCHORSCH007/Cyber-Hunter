using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	public int currentHealth;
	public HealthBar healthBar;
	public Rigidbody2D rb;
	static bool isDead;
	private GameObject DeathScreen;
	
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = globalVarables.playerMaxHealth;
		healthBar.SetMaxHealth(globalVarables.playerMaxHealth);
		isDead = false;
		DeathScreen = GameObject.FindWithTag("DeathMenu");
		DeathScreen.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
		
		if(currentHealth<= 0)
		{
			isDead = true;
			DeathScreen.SetActive(true);
			Time.timeScale = 0;
		}
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

