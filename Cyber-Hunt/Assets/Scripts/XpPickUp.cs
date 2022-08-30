using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPickUp : MonoBehaviour
{
    private LevelSystem ls;
    private void Awake()
    {
        ls = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "XP")
        {
            ls.GainExperienceFlatRate(collision.GetComponent<XPcollect>().XpValue);
            Destroy(collision.gameObject);
        }
    }

}
