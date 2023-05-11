using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotator : MonoBehaviour
    
{
    [SerializeField] private Vector3 _rotation;
    public void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }

    public void setRotation(Vector3 rotaton)
    {
        _rotation = rotaton;
    }


}
