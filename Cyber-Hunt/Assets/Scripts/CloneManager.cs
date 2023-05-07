using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{

    [SerializeField] private GameObject [] Laser;
    [SerializeField] private GameObject Shield;
    [SerializeField] private EnemyHpScript hp;
    private float ActiveTime = 4f;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        Invoke("ActivateLasers", 2f);
    }

    private void ActivateLasers()
    {
        
        for(int i = 0; i < Laser.Length; i++)
        {
            Laser[i].SetActive(true);
        }
        Invoke("DeactivateLasers", ActiveTime);
    }

    private void DeactivateLasers()
    {
        for (int i = 0; i < Laser.Length; i++)
        {
            Laser[i].GetComponent<Animator>().SetBool("Enabled", false);
        }
        Invoke("DisableClones", 4f);
    }

    private void DisableClones()
    {
        GameObject[] Clones = GameObject.FindGameObjectsWithTag("Clone");

        for(int i = 0; i< Clones.Length; i++)
        {
            Clones[i].GetComponent<AlignToPosition>().returnToOrigin();
            
        }
        Invoke("DeactivateRotator", 3f);
    }

    private void DeactivateRotator()
    {
        Shield.SetActive(false);
        hp.Invincible = false;
        gameObject.SetActive(false);
    }

 }

