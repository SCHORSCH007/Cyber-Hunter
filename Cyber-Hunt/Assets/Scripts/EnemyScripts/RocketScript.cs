
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private LayerMask _RaycastLayerMask;
    private Vector3 movement;

    [SerializeField]
    private float lifetime;
    private GameObject p;

    [SerializeField]
    private float delay;
    
    

    void Start()
    {
        p = GameObject.FindWithTag("Player");      
        Invoke("Destroy", lifetime);
        InvokeRepeating("calculateNewMovement", 0, delay);
    }


    void Update()
    {

        transform.Translate(-movement * _moveSpeed * Time.deltaTime);


        // Raycast collision Detection
        RaycastHit2D hit = Physics2D.Raycast(transform.position, p.transform.position - transform.position, 0.01f, _RaycastLayerMask);

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


    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void calculateNewMovement()
    {
        movement =  transform.position - p.transform.position;
        movement.Normalize();
            
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        //this.transform.rotation.Set(0, 0, angle + 90, 0);
        this.transform.localEulerAngles = new Vector3(0, 0, angle + 90);

    }
}
