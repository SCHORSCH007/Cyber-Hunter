using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private Sprite p_r;
    [SerializeField] private Sprite p_l;

    private Vector2 movement = Vector2.zero;
    private float _dashVelocity = 0f;
    private bool isFacingRight;
    private bool alreadyFacingRight;
    private SpriteRenderer sp;
    

    private void Awake()
    {
        isFacingRight = false;
        alreadyFacingRight = true;
        sp = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }
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
        
        if (movement.x < 0)
        {
            isFacingRight = false;
            Debug.Log("is facing right" + isFacingRight);
        }
        else if (movement.x > 0)
        {
            isFacingRight = true;
            Debug.Log("is facing right" + isFacingRight);
        }
        
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        //movement

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        if (isFacingRight && !alreadyFacingRight)
        {
            sp.sprite = p_r;
            alreadyFacingRight = true;
        }
        else if (!isFacingRight && alreadyFacingRight)
        {
            sp.sprite = p_l;
            alreadyFacingRight = false;
            
        }

        if (_dashVelocity > 0)
        {
            rb.AddForce(rb.position + movement.normalized * _dashVelocity * Time.fixedDeltaTime);
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
