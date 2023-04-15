
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private LevelSystem ls;
    private Player player;
    private void Awake()
    {
        ls = GameObject.FindWithTag("Player").GetComponent<LevelSystem>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "XP")
        {
            ls.GainExperienceFlatRate(collision.GetComponent<XPcollect>().XpValue);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "HP")
        {
            player.heal(collision.GetComponent<EnergyPack>().HealthAmount);
            Destroy(collision.gameObject);
        }
    }

}
