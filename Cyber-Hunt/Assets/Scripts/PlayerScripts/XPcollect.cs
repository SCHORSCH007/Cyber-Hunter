
using UnityEngine;

public class XPcollect : MonoBehaviour
   
{
    public int XpValue;
    [HideInInspector]  public bool moveToPlayer;
    public Rigidbody2D rb;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(this, 60f);

    }
    public void FixedUpdate()
    {
        if (moveToPlayer)

        {
            Vector3 direction = player.position - transform.position;
            rb.velocity = direction * 5;
        }
 
}
}
