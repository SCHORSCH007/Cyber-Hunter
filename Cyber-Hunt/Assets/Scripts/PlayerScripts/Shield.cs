using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private int hP = 5;

    [SerializeField] 
    private int maxHP = 5;

    [SerializeField] 
    private int rechargeTime;

    private Player _Player;
    private Manager Manager;



    // Update is called once per frame
    private void Start()
    {
        Manager = GameObject.FindWithTag("assets").GetComponent<Manager>();
        _Player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (gameObject != null)
        {
            if (hP <= 0)
            {
                Manager.BeginnShieldReset(rechargeTime);
                gameObject.SetActive(false);
            }
        }
    }

    public void DamageShield(int damage)
    {
        if (damage <= hP)
        {
            hP -= damage;
        }
        else
        {
            int playerDamage = damage - hP;
            _Player.TakeDamage(playerDamage);
            hP = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHpScript enemyHpScript = collision.gameObject.GetComponent<EnemyHpScript>();
        if (enemyHpScript != null)
        {
            if (enemyHpScript.health >= hP)
            {
                enemyHpScript.TakeDamage(hP);
                hP = 0;
            }
            else
            {
                hP -= enemyHpScript.health;
                enemyHpScript.TakeDamage(enemyHpScript.health);
            }
        }
    }

    private void OnEnable()
    {
        hP = maxHP;
    }
}
