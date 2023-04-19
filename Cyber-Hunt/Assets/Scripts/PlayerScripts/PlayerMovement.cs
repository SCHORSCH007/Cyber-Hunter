using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float og_moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private Sprite p_r;
    [SerializeField] private Sprite p_l;

    private Vector2 movement = Vector2.zero;
    private float _dashVelocity = 0f;
    private bool isFacingRight;
    private bool alreadyFacingRight;
    private SpriteRenderer sp;
    private float countdown_dash;
    private float delay_dash;
    private float moveSpeed;

    private void Awake()
    {
        isFacingRight = false;
        alreadyFacingRight = true;
        sp = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        moveSpeed = og_moveSpeed;
    }
    public float MoveSpeed
    {
        get => og_moveSpeed;
        set => og_moveSpeed = value; 
    }


    // Update is called once per frame
    void Update()
    {
       
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0 && movement.y < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 135);
        }
        else if (movement.x > 0 && movement.y > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, -45);
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else if (movement.x > 0 && movement.y < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, -135);
        }

        else {
            if (movement.x < 0)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 90);

            }
            if (movement.y < 0)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            if (movement.x > 0)
            {
                isFacingRight = true;
                gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            if (movement.y  > 0)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        //movement

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        if (isFacingRight && !alreadyFacingRight)
        {
           
            alreadyFacingRight = true;
        }
        else if (!isFacingRight && alreadyFacingRight)
        {
            
            alreadyFacingRight = false;
            
        }

        if (countdown_dash > 0)
        {
            if (delay_dash > 0)
            {
                delay_dash--;
            }
            else
            {
                moveSpeed = _dashVelocity;
                countdown_dash--;
                if (countdown_dash == 0)
                {
                    moveSpeed = og_moveSpeed;
                }
                delay_dash = 0; 
            }
        }
        
        
    }

    public void dash(float dashVelocity, float duration, float delay)
    {
        // rb.AddForce(rb.position + movement.normalized * dashVelocity);
        _dashVelocity = dashVelocity;
        countdown_dash = duration;
        delay_dash = delay;
        GameObject.FindWithTag("ParticleSystemDash").GetComponent<ParticleSystem>().Play();
        Debug.Log("dash");
    }

   

}
