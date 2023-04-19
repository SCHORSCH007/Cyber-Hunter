using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerObject : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y-1f + yOffset,0);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
