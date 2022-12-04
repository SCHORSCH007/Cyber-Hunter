using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    [SerializeField] 
    private float _moveSpeed = 1f;

    [SerializeField] 
    private int _Damage = 1;

    [SerializeField]
    private LayerMask _RaycastLayerMask;

    private Vector2 moveVec;
    public int damage
    {
        get => _Damage;
        set => _Damage = value;
    }

    [SerializeField] private float lifetime;

    private GameObject _Player;

    

    private void Start()
    {       
        _Player = GameObject.FindWithTag("Player");
    }
    private void OnEnable()
    {
        Invoke("Destroy", lifetime);
    }

    public void Update()
    {


        transform.Translate(moveVec * _moveSpeed * Time.deltaTime);

        
    // Raycast collision Detection
       RaycastHit2D hit = Physics2D.Raycast(transform.position, _Player.transform.position - transform.position, 0.01f,_RaycastLayerMask);

        if (hit.collider != null)
        {
            // check if shield was hit
            Shield s = hit.collider.gameObject.GetComponent<Shield>();
            if (s != null)
            {
                s.DamageShield(damage);              
            }
            // if not check if player was hit
            else
            {
                Player p = hit.collider.gameObject.GetComponentInParent<Player>();
                if (p != null)
                {
                    p.TakeDamage(damage);                
                }
            }
           
            Destroy();
        }       
    }
    

    //set direction of the Bullet
    public void setMoveDirection(Vector2 target)
    {
       moveVec = target;
    }

    //return Bullet to pool
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    //Cancle Invoke
    private void OnDisable()
    {
        CancelInvoke();
    }

}


