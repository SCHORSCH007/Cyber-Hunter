
using UnityEngine;

public class RotationBlocker : MonoBehaviour
{
    [SerializeField]
    private GameObject _anchor;
    void Update()
    {
        Transform temp = _anchor.GetComponent<Transform>();
     
     transform.rotation = Quaternion.identity;

        this.transform.position = new Vector3(temp.position.x, (temp.position.y +1), transform.position.z);

     
    }
}
