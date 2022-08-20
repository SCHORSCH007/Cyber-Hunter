using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 MousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire = true;
    public float attackSpeed = 1f;
    private float delay = 1f;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotaton = MousePos - transform.position;

        float rotZ = Mathf.Atan2(rotaton.y, rotaton.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(Input.GetMouseButton(0)&&canFire&&Time.time > delay)
        {
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            delay = Time.time + attackSpeed;
        }
    }
}
