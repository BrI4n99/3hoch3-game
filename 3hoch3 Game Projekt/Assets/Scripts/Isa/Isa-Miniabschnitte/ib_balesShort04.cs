using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesShort04 : MonoBehaviour
{

    ib_balesMethPos meth;
 
    
    // Start is called before the first frame update
    void Start()
    {

        GameObject eins = new GameObject(); 
        GameObject zwei = new GameObject(); 
        eins.transform.parent = gameObject.transform;
        zwei.transform.parent = gameObject.transform;
        // Kurzer Abschnitt 04 [72] -----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse

        meth.hoch(ib_balesMethPos.posX[Random.Range(0, 3)], ib_balesMethPos.posY[0], ib_balesMethPos.abstand*i, false, true, gameObject); i++;
        meth.lang(ib_balesMethPos.posX[Random.Range(0, 3)], ib_balesMethPos.posY[0], ib_balesMethPos.abstand*i, ib_balesMethPos.randBool, true, gameObject); 
        
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
