using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWings : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Afterwings;
    [SerializeField]
    private GameObject levelUpMenu;

    [SerializeField]
    private ParticleSystem Sparks_R;
    [SerializeField]
    private ParticleSystem Sparks_L;
 

    public void ActivateWings1()
    {
        Afterwings[0].SetActive(true);
        Afterwings[1].SetActive(true);
    }

    public void ActivateWings2()
    {
        Afterwings[2].SetActive(true);
        Afterwings[3].SetActive(true);
        Sparks_R.Emit(30);
        Sparks_L.Emit(30);
    }

    public void ActivateWings3()
    {
        Afterwings[4].SetActive(true);
        Afterwings[5].SetActive(true);
    }

    public void Deactivate()
    {
      
        levelUpMenu.SetActive(true);
        Time.timeScale = 0;
       
    }

    public void ResetWings()
    {
        for (int i = 0; i < Afterwings.Length - 1; i++)
        {
            Afterwings[i].SetActive(false);
        }
        Afterwings[6].SetActive(false);
    }
    

}
