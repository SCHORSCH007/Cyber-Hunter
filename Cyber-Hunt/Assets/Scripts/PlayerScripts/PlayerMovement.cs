using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb = null;

    private Vector2 movement = Vector2.zero;

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
    }

    public void dash(float dashVelocity)
    {
        rb.AddForce(rb.position + movement.normalized * dashVelocity);
        
        Debug.Log("dash");
    }
    
}
