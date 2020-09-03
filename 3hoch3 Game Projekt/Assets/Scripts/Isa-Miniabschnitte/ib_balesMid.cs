using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balesMid : MonoBehaviour
{
    public int miniabschnitt; 
    public Vector3 abschnittPos; 
    ib_balesMethPos meth;

    public GameObject fence; 
    
    // Start is called before the first frame update
    void Start()
    {
        // Langer Abschnitt 02 [144]-----------------------------------------------------------------------------------
        meth = ib_balesMethPos.Instance;
        int i = 1; // Anzahl der Hindernisse
        int lr = Random.Range(0, 2);
        if (lr == 1) lr = 2;
        
        meth.drei(ib_balesMethPos.posX[0],     ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, gameObject);  i++;   lr = -lr; 
        meth.hoch(ib_balesMethPos.posX[Random.Range(0, 3)],               ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, true, false, gameObject);                                        i++;   
        meth.vier(ib_balesMethPos.posX[2+lr],     ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i, gameObject);                     i++; lr = -lr; 
        meth.breit(ib_balesMethPos.posX[0],     ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i,   true, false, gameObject);  i++;     
    

        // Zaunelemente - erstellen
            Vector3 posF1 =   new Vector3(-46,  0, 28); 
            GameObject fencePart1 = Instantiate(fence, transform, false); 
            fencePart1.name = string.Format("fence1"); 
            fencePart1.transform.Translate(posF1);
            fencePart1.transform.Rotate(0, 90, 0);
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
