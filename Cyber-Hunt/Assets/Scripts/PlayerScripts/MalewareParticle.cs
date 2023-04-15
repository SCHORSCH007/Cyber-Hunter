using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalewareParticle : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        EnemyHpScript Enemy = other.gameObject.GetComponent<EnemyHpScript>();
        Enemy.AplyMaleware();
    }
}





