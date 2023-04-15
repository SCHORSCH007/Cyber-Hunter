using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private CircleCollider2D collPlayer;
    [HideInInspector] public bool inRange;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        collPlayer = player.GetComponent<CircleCollider2D>();
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        
        if (!inRange)
        { moveCharacter(movement); }
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }

   
}

