
using UnityEngine;

public class EnemyRocketShooting : MonoBehaviour
{
    [SerializeField]
    private float _attackSpeed = 1f;

    [SerializeField]
    private GameObject rocket;

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
        Instantiate(rocket, this.transform.position, Quaternion.identity);
    }
}
