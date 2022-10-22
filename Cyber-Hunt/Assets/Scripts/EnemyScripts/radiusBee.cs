using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiusBee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		BeeScript bs = collision.GetComponent<BeeScript>();
		if (bs != null)
		{
			bs.inRange = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{

		BeeScript bs = collision.GetComponent<BeeScript>();
		if (bs != null)
		{
			bs.inRange = false;
		}
	}
}
