using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{
    public int maxHealth = 3;
    [SerializeField] GameObject drop;
    [HideInInspector] public int health;

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
