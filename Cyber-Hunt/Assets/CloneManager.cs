using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{

    [SerializeField] private GameObject [] Laser;
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
        gameObject.SetActive(false);
    }

 }

