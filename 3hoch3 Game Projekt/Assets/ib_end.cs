using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ib_end : MonoBehaviour
{
    
    public GameObject pyra; 
    public GameObject trog; 
    public GameObject fence; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject newTrog = Instantiate(trog, transform, false); newTrog.name = string.Format("newTrog"); 
        newTrog.transform.Translate(new Vector3(-24, 0, 65)); newTrog.transform.Rotate(270, 0, 0);
        GameObject newPyra = Instantiate(pyra, transform, false); newPyra.name = string.Format("newPyra"); 
        newPyra.transform.Translate(new Vector3(0, 0, 0));
        GameObject newFence = Instantiate(fence, transform, false); newFence.name = string.Format("newFence");
        newFence.transform.Translate(new Vector3(-46, 0, 75)); newFence.transform.Rotate(0, 90, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
