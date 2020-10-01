using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_eggsInBasket : MonoBehaviour
{
    public GameObject eggs;
    public GameObject basket; 
    ib_balesMethPos meth;
    public Vector3 eggPos = new Vector3(-24, 0.5f, 18);
    public Vector3 basketPos = new Vector3(-16, -24, 0);
    
    // Start is called before the first frame update
    void Start()
    {

        // Objekte instanziieren: Ei, Korb, Heuballen mit Möhren        
        GameObject rollingEgg = Instantiate(eggs, transform, false);  
        rollingEgg.transform.Translate(eggPos);
        rollingEgg.name = string.Format("rollingEgg");
     
        GameObject thisBasket = Instantiate(basket, transform, false); 
        thisBasket.transform.Translate(basketPos);
        thisBasket.name = string.Format("thisBasket");
        
        meth = ib_balesMethPos.Instance;
        float i = 1.5f; // Anzahl der Hindernisse
        int lr1 = 2;
        int lr2 = 0;   

        meth.einfach(ib_balesMethPos.posX[lr1], ib_balesMethPos.posY[0], ib_balesMethPos.abstand*i, false, false, gameObject).transform.parent = gameObject.transform; i++;
        meth.einfach(ib_balesMethPos.posX[lr2], ib_balesMethPos.posY[0], ib_balesMethPos.abstand*i, true, false, gameObject).transform.parent = gameObject.transform; i++;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
