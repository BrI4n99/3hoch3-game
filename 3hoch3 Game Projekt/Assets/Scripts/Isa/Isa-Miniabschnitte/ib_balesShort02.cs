using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesShort02 : MonoBehaviour
{

    ib_balesMethPos meth;
    public GameObject puddle;

    // Start is called before the first frame update
    void Start()
    {
        // Kurzer Abschnitt 02 [72] -----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse
        meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)], ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, ib_balesMethPos.createRandBool(), ib_balesMethPos.createRandBool(), gameObject);  i++;
        meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)], ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, false, ib_balesMethPos.createRandBool(), gameObject);  
        Instantiate(puddle, transform).transform.Translate(0, -0.5f, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
