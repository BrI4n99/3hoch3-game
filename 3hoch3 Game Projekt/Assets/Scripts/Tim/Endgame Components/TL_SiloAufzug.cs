using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_SiloAufzug : MonoBehaviour
{
    private float startPos;
    private float endPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        endPos = -18.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
