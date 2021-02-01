using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDie : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (tag == "Dead")
            Destroy(gameObject, 1.0f);
    }


}
