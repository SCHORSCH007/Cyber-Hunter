using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnCollisionEnter2D(Collision2D collision)
	{
		{
			EnemyHpScript ES = collision.gameObject.GetComponent<EnemyHpScript>();
			Player p = GameObject.FindWithTag("Player").GetComponent<Player>();
			if (ES != null && collision.gameObject.tag != "Boss")

			{
				p.TakeDamage(ES.health);
				ES.TakeDamage(ES.GetMaxHealth()/2);
			}
			

		}
	}
}