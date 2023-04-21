using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterimage : MonoBehaviour
{
    [SerializeField] private ParticleSystem parSys;
    
  void SyncParticles()
    {
        var main = parSys.main;
        main.startRotationZ = transform.rotation.eulerAngles.z * -Mathf.Deg2Rad;
    }



    // Update is called once per frame
    void Update()
    {
        SyncParticles();
    }
}
