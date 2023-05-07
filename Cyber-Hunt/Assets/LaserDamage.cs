
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = GameObject.FindWithTag("Player").GetComponent<Player>();
        if(collision.gameObject.tag == "col")
        {
            p.TakeDamage(15);
        }
    }
}
