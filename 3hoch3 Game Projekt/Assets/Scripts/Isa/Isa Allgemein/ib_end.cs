using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ib_end : MonoBehaviour
{
    
    public GameObject pyra; 
    public GameObject trog; 
    public GameObject fence;
    public GameObject carrot;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newTrog = Instantiate(trog, transform, false); newTrog.name = string.Format("newTrog"); 
        newTrog.transform.Translate(new Vector3(-24, 0, 75)); newTrog.transform.Rotate(270, 0, 0);
        GameObject newPyra = Instantiate(pyra, transform, false); newPyra.name = string.Format("newPyra"); 
        newPyra.transform.Translate(new Vector3(0, 0, 0));
        GameObject newFence = Instantiate(fence, transform, false); newFence.name = string.Format("newFence");
        newFence.transform.Translate(new Vector3(-46, 0, 100)); newFence.transform.Rotate(0, 90, 0);
        GameObject newCarrot = Instantiate(carrot, transform, false); newCarrot.name = string.Format("newCarrot");
        newCarrot.transform.Translate(new Vector3(-24, 3, 87));
        GameObject newCarrot2 = Instantiate(carrot, transform, false); newCarrot2.name = string.Format("newCarrot2");
        newCarrot2.transform.Translate(new Vector3(-40, 2, 125));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
