using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {

        globalVarables.Victory = true;
    }
}

