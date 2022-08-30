using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public float force;
    public int damage = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
       
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);


    }

    // Update is called once per frame
    void Update()
    {
   
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        EnemyHpScript enemy = hitInfo.GetComponent<EnemyHpScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            DamagePopUpScript.Create(enemy.transform.position, damage, false);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
