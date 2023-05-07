using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private int damage = 1;
    [SerializeField] private int lifetime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",lifetime);
        mainCamera = Camera.main;
       
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        EnemyHpScript enemy = hitInfo.GetComponent<EnemyHpScript>();
        EnemyShield s = hitInfo.GetComponent<EnemyShield>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage * globalVarables.increasingDamage);
            DamagePopUpScript.Create(enemy.transform.position, damage*globalVarables.increasingDamage, false,new Color(26f/255f,170f/255f,207f/255f));
            Destroy(gameObject);
        }    
        if(s!= null)
        {
            Destroy();
        }
    }
}
