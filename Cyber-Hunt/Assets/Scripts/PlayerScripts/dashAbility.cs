using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class dashAbility : Ability
{
    public float dashVelocity;
    public float duration;
    public float delay;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();


        //rb.velocity = movement.movement.normalized * dashVelocity;
        movement.dash(dashVelocity, duration, delay);

        //m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
        //m_Rigidbody2D.AddForce(new Vector2(m_DashForce, m_DashForce / 10));
    }
}
