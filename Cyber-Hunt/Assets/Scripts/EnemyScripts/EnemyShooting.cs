using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    
    
    [SerializeField]
    private float _attackSpeed = 1f;

    [SerializeField]
    private float AttackRange = 0f;

    private Vector2 target;

    private float delay = 1f;
    //bullet Sin and Cos
    private float X;
    private float Y;
    private GameObject _Player;


    private void Awake()
    {


        _Player = GameObject.FindWithTag("Player");
        delay = Random.Range(1f, 3f);
        InvokeRepeating("Fire", delay, _attackSpeed);

    }
    // Update is called once per frame
  
    private void Fire()
    {
        float dist = Vector3.Distance(_Player.transform.position, transform.position);
        if (dist <= AttackRange)
        {


            X = Mathf.Cos((transform.rotation.z + 90 * Mathf.PI) / 180);
            Y = Mathf.Sin((transform.rotation.z + 90 * Mathf.PI) / 180);

            target = new Vector2(X, Y);

            Vector3 bulMoveVector = transform.forward;


            GameObject bul = EnemyBulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBulletScript>().setMoveDirection(target);
        }
    }
}
