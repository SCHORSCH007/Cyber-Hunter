 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform pfDamagePopUp;
    void Start()
    {
        Instantiate(pfDamagePopUp, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
