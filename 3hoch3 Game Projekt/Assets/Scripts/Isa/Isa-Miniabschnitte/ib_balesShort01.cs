using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesShort01 : MonoBehaviour
{    
    ib_balesMethPos meth;
    public GameObject puddle;
    
    // Start is called before the first frame update
    void Start()
    {
        // Kurzer Abschnitt 01 [72]-----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse
        
        // Methodenaufrufe
         meth.drei(ib_balesMethPos.posX[Random.Range(0, 3)],   ib_balesMethPos.posY[0], (ib_balesMethPos.abstand ) * i - 10, gameObject);          i++;                                                      
         meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)],  ib_balesMethPos.posY[0], (ib_balesMethPos.abstand ) * i - 10, ib_balesMethPos.createRandBool(),  true, gameObject);
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}