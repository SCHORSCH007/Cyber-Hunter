using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D col;

    private void Start()
    {
        col.enabled = false;
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void ActivateCollider()
    {
        col.enabled = true;
    }
    public void DeactivateCollider()
    {
        col.enabled = false;
    }
}
