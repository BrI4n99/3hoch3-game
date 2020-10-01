using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_poisonBarrEnd : MonoBehaviour
{

    public GameObject eins;
    public GameObject zwei;
    public GameObject drei;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Tonnen löschen, wenn diese zu weit in den nächsten Abschnitt geraten
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ib_poison")
        {
            Destroy(other, 0.1f);
        }
    }

}
