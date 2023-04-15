using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Drop
{
    public string Name;

    public GameObject prefab;

    [Range(0, 100f)] public float Chance = 100f;

    [HideInInspector] public double _weight;
}

public class EnemyHpScript : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private Drop[] drops;
    [SerializeField] private GameObject MalewareEffect;
    [SerializeField] private TextMeshProUGUI Kills;
    [SerializeField] private HealthBar _healtBar;
    


    public int health;
    private bool Maleware;
    private Spawner spawn;


    private void Start()
    {
        Kills = GameObject.FindWithTag("Killcount").GetComponent<TextMeshProUGUI>();
        health = maxHealth;
        spawn = GameObject.FindWithTag("assets").GetComponent<Spawner>();
        if (_healtBar != null)
        {
            _healtBar.SetMaxHealth(maxHealth);
        }
    }
    public void TakeDamage(int Damage)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 151);
        StartCoroutine(colorFeedback());
        health -= Damage;
        if (_healtBar != null)
        {
            _healtBar.SetHealth(health);
        }
        if (health <= 0)
        {
            DropItems();
            
            spawn.ReduceEnemys(1);
            globalVarables.kills++;
            Kills.SetText(globalVarables.kills.ToString());
            Destroy(gameObject);

        }
    }
    IEnumerator colorFeedback()
    {
        yield return new WaitForSeconds(0.2f);
        if (Maleware)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(57f / 255f, 200f / 255f, 66f / 255f);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }
    IEnumerator MalewareLoop(int Damage, float Duration)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(57f / 255f, 200f / 255f, 66f / 255f);
        Instantiate(MalewareEffect, gameObject.transform);

        EffectLifetime Lifetime = GetComponentInChildren<EffectLifetime>();
        Lifetime.EndInSeconds(Duration);
        int _damage = Damage;
        float timeLeft = Duration;

        while (timeLeft > 0.0f)
        {
            TakeDamage(1);
            DamagePopUpScript.Create(transform.position, 1, false, new Color(57f / 255f, 200f / 255f, 66f / 255f));
            timeLeft -= Time.deltaTime;
            yield return new WaitForSeconds(Duration / Damage);
        }
        Maleware = false;
        yield return null;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void AplyMaleware()
    {
        if (!Maleware)
        {
            Maleware = true;
            StartCoroutine(MalewareLoop(3, 9));
        }
    }

    private void DropItems()
    {
        
        
       

        for (int i = 0; i < drops.Length;i++)
        {
            float r = Random.Range(0f, 100f);
            Vector2 position = new Vector2(gameObject.transform.position.x + Random.Range(-0.2f, 0.2f), gameObject.transform.position.y + Random.Range(-0.2f, 0.2f));
            if (r <= drops[i].Chance)
            {
                Instantiate(drops[i].prefab,position, Quaternion.identity);
                
            }
         }
        return;
     }
 }