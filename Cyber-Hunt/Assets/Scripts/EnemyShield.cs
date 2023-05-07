using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
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
        hP = maxHP;
       
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (p.gameObject.tag == "col")
        {
            p.TakeDamage(20);
        }
    }



    private void OnEnable()
    {
        hP = maxHP;
    }
}
