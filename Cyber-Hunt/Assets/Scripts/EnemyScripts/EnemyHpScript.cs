using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHpScript : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] GameObject drop;
    [SerializeField] GameObject MalewareEffect;
    [SerializeField] private TextMeshProUGUI Kills;
    public int health;
    private bool Maleware;
    private Spawner spawn;
    
    

    private void Start()
    {
        Kills = GameObject.FindWithTag("Killcount").GetComponent<TextMeshProUGUI>();
        health = maxHealth;
        spawn = GameObject.FindWithTag("assets").GetComponent<Spawner>();
    }
    public void TakeDamage(int Damage)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 151);
        StartCoroutine(colorFeedback());
        health -= Damage;
        if(health <= 0)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
            spawn.ReduceEnemys(1);
            globalVarables.kills++;
            Kills.SetText(globalVarables.kills.ToString());
           

        }               
    }
    IEnumerator colorFeedback()
    {
        yield return new WaitForSeconds(0.2f);
        if (Maleware)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(57f/255f,200f/255f,66f/255f);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }
    IEnumerator MalewareLoop(int Damage,float Duration)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(57f/255f, 200f/255f, 66f/255f);
        Instantiate(MalewareEffect, gameObject.transform);

        EffectLifetime Lifetime = GetComponentInChildren<EffectLifetime>();
        Lifetime.EndInSeconds(Duration);
        int _damage = Damage;
        float timeLeft = Duration;

        while(timeLeft > 0.0f)
        {
            TakeDamage(1);
            DamagePopUpScript.Create(transform.position,1, false, new Color(57f / 255f, 200f / 255f, 66f / 255f));
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
}
