using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
        private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private int Damage = 1;
    public int damage
    {
        get => Damage;
        set => Damage = value;
    }
    private Transform player;
    [SerializeField] private float lifetime;
        Player p;
        private float currentTime;


    void Start()
        {
        p = GameObject.FindWithTag("Player").GetComponent<Player>();
        player = GameObject.FindWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
        currentTime = Time.time;

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90);
        }
   
    private void FixedUpdate()
    {
        if (lifetime + currentTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
        {

        
        XpPickUp x = hitInfo.GetComponent<XpPickUp>();
             
            if(x != null)
            {
            p.TakeDamage(damage);
            Destroy(gameObject);
            }          
        }
    }
