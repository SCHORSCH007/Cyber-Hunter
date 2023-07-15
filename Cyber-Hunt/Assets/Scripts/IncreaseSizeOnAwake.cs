
using UnityEngine;

public class IncreaseSizeOnAwake : MonoBehaviour
{
    [SerializeField] private float growSpeed;


    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f,1f);
    }
    // Update is called once per frame
    
    private void FixedUpdate()
    {

        if (gameObject.transform.localScale.x < 1f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + growSpeed, gameObject.transform.localScale.y + growSpeed, 1f);
        }
    }
}
