using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterRotate : MonoBehaviour
{


    public Transform child;

    void Update()
    {
        child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
