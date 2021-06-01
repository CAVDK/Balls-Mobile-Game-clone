using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSize : MonoBehaviour
{
    public GameObject rezisedblock;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.localScale = rezisedblock.transform.localScale;
    }
}
