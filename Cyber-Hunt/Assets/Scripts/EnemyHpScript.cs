using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{

    [SerializeField] int maxHealth = 3;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        if(health <= 0)
        {
          //  GetComponent<ParticleSystem>().Play();
         //   ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
           // em.enabled = true;
            Destroy(gameObject);
        }
    }
}
