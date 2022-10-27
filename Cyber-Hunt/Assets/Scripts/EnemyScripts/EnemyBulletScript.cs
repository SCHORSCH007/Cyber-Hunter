using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    [SerializeField] 
    private float _moveSpeed = 1f;

    [SerializeField] 
    private int _Damage = 1;

    private Vector2 moveVec;
    public int damage
    {
        get => _Damage;
        set => _Damage = value;
    }
    [SerializeField] private float lifetime;


    private void OnEnable()
    {
        Invoke("Destroy", lifetime);  
    }

    public void Update()
    {
        transform.Translate(moveVec * _moveSpeed * Time.deltaTime);     
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
