using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpiderBossAttacks : MonoBehaviour
{
    private EnemyScript enemy;
    private Transform player;
    private Rigidbody2D rb;
    private Vector3 movement;
    [SerializeField] private float DashSpeed;
    private bool DashActive = false;
    private int dashes;
    [SerializeField] private Light2D lightCalm;
    [SerializeField] private Light2D lightRage;
    private int DefaulDashAmount = 3;
    private int DefaultReactivationDelay = 10;
    private float DelayUntilDash = 0.5f;
    private float Duration = 1f;
    private float RepeatDelay = 2f;
    private EnemyHpScript HP;
    private bool rage = false;
    private Player PlayerHP;
    private Light2D activeLight;
    private BoxCollider2D otherCol;
    private bool HitPlayer;
   

    void Start()
    {
        enemy = gameObject.GetComponent<EnemyScript>();
        player = GameObject.Find("Player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        HP = gameObject.GetComponent<EnemyHpScript>();
        otherCol = GameObject.FindWithTag("col").GetComponent<BoxCollider2D>();
        PlayerHP = GameObject.FindWithTag("Player").GetComponent<Player>();
        Dash(DefaulDashAmount, 4);
        activeLight = lightCalm;
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement p = other.GetComponent<PlayerMovement>();
        if(p != null)
        {
            PlayerHP.TakeDamage(20);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(HP.health < (HP.GetMaxHealth() - HP.GetMaxHealth() * 0.6) && !rage)
        {
          ActivateRage();
        }
        if (DashActive)
        {
            moveCharacter(movement);
        }
        
    }
    private void Update()
    {
        if (otherCol.bounds.Intersects(gameObject.GetComponent<BoxCollider2D>().bounds) && !HitPlayer)
        {
            PlayerHP.TakeDamage(20);
            HitPlayer = true;
            StartCoroutine(ImunityFrame(1));
        }
        
   
    }

    private void Dash(int amount,int startIn)
    {
        dashes = amount;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        InvokeRepeating("DashLogic", startIn, RepeatDelay);
        
    }

    private void DashLogic()
    {
        activeLight.intensity = 1.2f;
        enemy.pause(true);
        enemy.Dash = true;
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle + 90);
        direction.Normalize();
        movement = direction;
        StartCoroutine(accelerate(DelayUntilDash));
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * 8f * Time.deltaTime));
    }

    private void EndDash()
    {
        DashActive = false;
        enemy.pause(false);
        enemy.Dash = false;
       
    }
    public void ActivateRage()
    {
        activeLight = lightRage;
        lightCalm.gameObject.SetActive(false);
        lightRage.gameObject.SetActive(true);
        CancelInvoke("DashLogic");
        DefaulDashAmount = 5;
        DefaultReactivationDelay = 7;
        DelayUntilDash = 0.3f;
        Duration = 0.8f;
        RepeatDelay = 1.5f;
        Dash(DefaulDashAmount,2);
        rage = true;
    }
    IEnumerator accelerate(float number)
    {     
        {


            if (--dashes == 0)
            {
                CancelInvoke("DashLogic");
                Dash(DefaulDashAmount, DefaultReactivationDelay);
               // gameObject.GetComponent<Collider2D>().isTrigger = false
                activeLight.intensity = 1f;
            }          
                yield return new WaitForSeconds(number);
                DashActive = true;
                Invoke("EndDash", Duration);
            
        }
    }
    IEnumerator ImunityFrame(int sec)
    {
        yield return new WaitForSeconds(sec);
        HitPlayer = false;
    }
}
