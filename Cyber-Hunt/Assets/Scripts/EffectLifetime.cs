using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLifetime : MonoBehaviour
{
    // Start is called before the first frame update

    public void EndInSeconds(float Lifetime)
    {
        Invoke("Destroy", Lifetime);
        
    }
    private void Destroy()
    {
        Destroy(this);
    }
}
