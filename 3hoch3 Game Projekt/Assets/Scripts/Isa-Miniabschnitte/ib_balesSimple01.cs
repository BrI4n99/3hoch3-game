using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesSimple01 : MonoBehaviour
{
    public int miniabschnitt; 
    public Vector3 abschnittPos; 
    ib_balesMethPos meth;
    
    // Start is called before the first frame update
    void Start()
    {
        // Kurzer Abschnitt 01 [72]-----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse
        int lr = Random.Range(0, 2);
        if (lr == 1) lr = 2;
        
        meth.einfach(ib_balesMethPos.posX[0 + lr],               ib_balesMethPos.posY[0], ib_balesMethPos.abstand,       true,  true, gameObject);                     i++;     lr = -lr; 
        meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)],     ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i,   false, ib_balesMethPos.randBool, gameObject);  i++; 
        meth.hoch(ib_balesMethPos.posX[2 + lr],               ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, true, false, gameObject);                                        i++;   
        meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)],     ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i,   false,  true, gameObject);                     i++; 
        meth.drei(ib_balesMethPos.posX[Random.Range(0, 3)],      ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, gameObject);                                     i++;   
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
