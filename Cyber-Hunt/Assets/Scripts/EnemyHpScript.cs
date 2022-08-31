using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{

    [SerializeField] int maxHealth = 3;
    [SerializeField] GameObject drop;
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
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }               
    }  
}
