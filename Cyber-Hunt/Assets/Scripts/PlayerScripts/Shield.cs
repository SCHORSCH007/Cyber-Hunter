using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    int hP = 5;
    [SerializeField] int maxHP = 5;



    // Update is called once per frame
    void Update()
    {
        if (gameObject != null) { 
        if (hP <= 0)
        {
            gameObject.SetActive(false);
        }

    }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProj")
        {
            EnemyBulletScript EB = collision.gameObject.GetComponent<EnemyBulletScript>();
            hP -= EB.damage;
            Destroy(collision.gameObject);
        }
        EnemyHpScript ES = collision.gameObject.GetComponent<EnemyHpScript>();
        if (ES != null) 
        
        { 
            if (ES.health >= hP)
            {
            ES.TakeDamage(hP);
            hP = 0;
            }
            else
            {
            hP -= ES.health;
            ES.TakeDamage(ES.health);
            }
        }
    }
    
    private void OnEnable()
    {
        hP = maxHP;
    }
}
