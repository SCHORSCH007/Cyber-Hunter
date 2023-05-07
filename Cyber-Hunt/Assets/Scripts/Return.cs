
using UnityEngine;

public class Return : MonoBehaviour
{

    [SerializeField] KeyCode exit;
    [SerializeField] Manager m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(exit))
        {
            m.Resume();
        }
    }
}
