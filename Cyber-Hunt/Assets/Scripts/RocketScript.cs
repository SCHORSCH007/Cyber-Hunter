using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public int damage = 1;
    private Transform player;
    public float lifetime;
    Player p;
    private float startTime;
    private Vector3 movement;
    private float delay;
    public float updatingDirection;
    private float angle;

    void Start()
    {
        p = GameObject.FindWithTag("Player").GetComponent<Player>();
        player = GameObject.FindWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90);
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position; 
        direction.Normalize();
        movement = direction;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }


    private void FixedUpdate()
    {
        if (lifetime + startTime < Time.time)
        {
            Destroy(gameObject);
        }
        else
        {  
            if (Time.time > delay)
            {
                Vector3 direction = player.position - transform.position;
                direction.Normalize();
                rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


                //rb.MovePosition((Vector3)transform.position + (movement * force * Time.deltaTime));
                rb.rotation = angle - 90f;
                delay = Time.time + updatingDirection;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        XpPickUp x = hitInfo.GetComponent<XpPickUp>();

        if (x != null)
        {
            p.TakeDamage(damage);
            Destroy(gameObject);
        }
    }






}
