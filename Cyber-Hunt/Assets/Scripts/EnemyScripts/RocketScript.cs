
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

    [SerializeField]
    private float InitialDelay = 0f;

    private GameObject parent;


    private void Awake()
    {
        p = globalVarables.Player;
        parent = GameObject.FindWithTag("BossDrone");
        
    }
    void Start()
    {
       
        
        Invoke("Destroy", lifetime);
        if (InitialDelay > 0f)
        {
            Invoke("initialCalculation", 0.01f);
        }
        else
        {
            InvokeRepeating("calculateNewMovement", 0, delay);
        }
        
    }


    void Update()
    {
       
        Vector3 movementReal = movement * _moveSpeed * Time.deltaTime;
        transform.position = transform.position + movementReal;
        Debug.Log(movementReal);

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

    

    public void calculateNewMovement()
    {

        Vector3 direction = p.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        //Vector3 direction2 = p.transform.position - transform.position;
        movement = direction.normalized;
        
    }
    public void initialCalculation()
    {
        InvokeRepeating("calculateNewMovement", InitialDelay, delay);
        
       
       
        Quaternion rotation = parent.transform.rotation;
        transform.rotation = rotation;
        Vector2 direction = transform.up;

        //Vector3 direction2 = p.transform.position - transform.position;
        movement = direction.normalized;
        
    } 
}

