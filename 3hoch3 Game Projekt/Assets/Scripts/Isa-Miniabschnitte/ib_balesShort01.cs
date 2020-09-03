using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesShort01 : MonoBehaviour
{    
    ib_balesMethPos meth;
    
    // Start is called before the first frame update
    void Start()
    {
        // Kurzer Abschnitt 01 [72]-----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse
        
         meth.drei(ib_balesMethPos.posX[Random.Range(0, 3)],   ib_balesMethPos.posY[0], ib_balesMethPos.abstand *i, gameObject);          i++;                                                      
         meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)],  ib_balesMethPos.posY[0], ib_balesMethPos.abstand *i, ib_balesMethPos.randBool,  true, gameObject);  
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}