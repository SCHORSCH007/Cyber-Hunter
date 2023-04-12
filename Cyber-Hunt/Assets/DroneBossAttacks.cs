
using UnityEngine;

public class DroneBossAttacks : MonoBehaviour
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
    private bool rotation = false;


    private void Awake()
    {


        _Player = GameObject.FindWithTag("Player");
        Invoke("RocketStorm", 4);

    }
    private void Update()
    {
        if (rotation)
        {
            gameObject.transform.Rotate(0, 0, 60 * Time.deltaTime);
        }
    }
    // Update is called once per frame

    private void Fire()
    {
        Instantiate(rocket, this.transform.position, Quaternion.identity);
    }
    private void RocketStorm()
    {
        gameObject.GetComponent<EnemyScript>().pause(true);
        rotation = true;
      
        {
            InvokeRepeating("Fire", 0.05f,0.05f);
            Invoke("Cancel", 6);
            
           
        }
        
    }
    private void Cancel()
    {
        CancelInvoke();
        gameObject.GetComponent<EnemyScript>().pause(false);
        rotation = false;
    }
}
