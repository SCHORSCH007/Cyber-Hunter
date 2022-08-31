using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public bool canFire = true;
    public float attackSpeed = 1f;
    private float delay = 1f;
    public GameObject bullet;
    public Transform bulletTransform;
   

    // Update is called once per frame
    void Update()
    {
        if (canFire && Time.time > delay)
        {
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            delay = Time.time + attackSpeed;
        }
    }
}
