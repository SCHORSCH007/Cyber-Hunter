using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb = null;

    private Vector2 movement = Vector2.zero;
    private float _dashVelocity = 0f;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value; 
    }


    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        if(_dashVelocity > 0)
        {
            rb.AddForce(rb.position + movement.normalized * _dashVelocity * Time.deltaTime);
            //_dashVelocity = 0f;
        }
        
    }

    public void dash(float dashVelocity)
    {
        // rb.AddForce(rb.position + movement.normalized * dashVelocity);
        _dashVelocity = dashVelocity;
        Debug.Log("dash");
    }
    
}
