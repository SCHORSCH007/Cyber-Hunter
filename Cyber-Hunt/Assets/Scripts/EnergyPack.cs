using UnityEngine;

public class EnergyPack : MonoBehaviour

{
    public int HealthAmount;
    [HideInInspector] public bool moveToPlayer;
    public Rigidbody2D rb;
    private Transform player;
    [SerializeField] private float pickupDistance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

    }
    public void FixedUpdate()
    {
        if ((player.position - transform.position).magnitude < pickupDistance&& !moveToPlayer)
        {
            moveToPlayer = true;

        }
        if (moveToPlayer)

        {
            Vector3 direction = player.position - transform.position;
            rb.velocity = direction * 5;
        }

    }
}