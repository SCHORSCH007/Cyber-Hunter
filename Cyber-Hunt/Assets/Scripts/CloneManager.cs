using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{

    [SerializeField] private GameObject [] Laser;
    [SerializeField] private GameObject Shield;
    [SerializeField] private EnemyHpScript hp;
    [SerializeField] private BeeBossAtacks Bee;
    [SerializeField] private GameObject[] Clones;
    private int loopVariable = 4;
    private float ActiveTime = 8f;
    private bool rage = false;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        if (!Bee.isEnraged())
        {
            Invoke("ActivateLasers", 2f);
        }
        else
        {
            if (rage)
            {
                Invoke("ActivateLasers", 2f);
            }
            else
            {
                rage = true;
                
                loopVariable = 6;
                Clones[4].SetActive(true);
                Clones[5].SetActive(true);
                gameObject.GetComponent<BladeRotator>().setRotation(new Vector3(0, 0, -70));
                Invoke("ActivateLasers", 2f);
            }
        }
    }

    private void ActivateLasers()
    {
        
        for(int i = 0; i < loopVariable; i++)
        {
            Laser[i].SetActive(true);
        }
        Invoke("DeactivateLasers", ActiveTime);
    }

    private void DeactivateLasers()
    {
        for (int i = 0; i < loopVariable; i++)
        {
            Laser[i].GetComponent<Animator>().SetBool("Enabled", false);
        }
        Invoke("DisableClones", 3f);
    }

    private void DisableClones()
    {
        

        for(int i = 0; i< loopVariable; i++)
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

