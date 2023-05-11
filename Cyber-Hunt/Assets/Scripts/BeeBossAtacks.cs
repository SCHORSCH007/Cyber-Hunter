using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BeeBossAtacks : MonoBehaviour
{
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Clones;
    [SerializeField] private EnemyHpScript hp;
    [SerializeField][Range(0, 1f)] private float HPToActivateRage;
    [SerializeField] private GameObject RageLight;
    private bool rage = false;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ActivateClones", 3f,12f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.health < hp.GetMaxHealth() * HPToActivateRage &&!rage)
        {
            Rage();
        };
    }

    private void ActivateClones()
    {
        if (!Clones.activeInHierarchy)
        {
            Clones.SetActive(true);
            Shield.SetActive(true);
            gameObject.GetComponent<EnemyHpScript>().Invincible = true;
        }
    }
    public void Rage()
    {
        rage = true;
        RageLight.SetActive(true);
        Clones.SetActive(false);
        Shield.SetActive(false);
        CancelInvoke();
        InvokeRepeating("ActivateClones", 0f, 10f);
       
        
    }
    public bool isEnraged()
    {
        return rage;
    }
    private void OnDestroy()
    {
        globalVarables.Bossfight = false;
    }
}
