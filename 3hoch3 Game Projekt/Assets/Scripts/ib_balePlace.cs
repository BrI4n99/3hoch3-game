using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balePlace : MonoBehaviour
{


    public GameObject bales;

    // Start is called before the first frame update
    void Start()
    {

    // Instanzen von Heuballen
    Vector3 balesPos2 = new Vector3(-24, 0, 140);
    GameObject bale1 = Instantiate(bales, balesPos2, gameObject.transform.rotation) ;




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
