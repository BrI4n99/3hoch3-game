using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_schild : MonoBehaviour
{

    public Animation schildWeg;

    // Start is called before the first frame update
    void Start()
    {
        schildWeg = gameObject.GetComponent<Animation>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeSign() {
        Debug.Log("Close");
        Destroy(transform.parent.gameObject);
        //schildWeg.Play("Schild02");
    }
}
