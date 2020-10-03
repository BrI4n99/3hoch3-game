﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesShort03 : MonoBehaviour
{
    ib_balesMethPos meth;
    public GameObject puddle;

    // Start is called before the first frame update
    void Start()
    {
        
        // Kurzer Abschnitt 03 [72] -----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse
        meth.einfach(ib_balesMethPos.posX[Random.Range(0, 3)],  ib_balesMethPos.posY[0], ib_balesMethPos.abstand*i,     true, ib_balesMethPos.randBool, gameObject);                     i++;
        meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)],   ib_balesMethPos.posY[0], ib_balesMethPos.abstand*i,     false,  true, gameObject);  
        Instantiate(puddle, transform).transform.Translate(0, -0.5f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
