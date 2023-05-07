using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBossAtacks : MonoBehaviour
{
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Clones;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ActivateClones", 3f,12f);
    }

    // Update is called once per frame
    void Update()
    {

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
}
