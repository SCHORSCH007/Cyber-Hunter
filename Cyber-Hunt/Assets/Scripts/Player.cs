using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
	public Rigidbody2D rb;
	

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}


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

