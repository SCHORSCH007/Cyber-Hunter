using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpScript : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] GameObject drop;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int Damage)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 151);
        StartCoroutine(colorFeedback());
        health -= Damage;
        if(health <= 0)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }               
    }
    IEnumerator colorFeedback()
    {
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
