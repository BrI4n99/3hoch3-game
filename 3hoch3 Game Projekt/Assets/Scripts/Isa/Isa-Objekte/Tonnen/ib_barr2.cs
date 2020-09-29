using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_barr2 : MonoBehaviour
{
    public GameObject fence; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject newFence1 = Instantiate(fence, transform, false); newFence1.name = string.Format("newFence1");
        newFence1.transform.Translate(new Vector3(-46, 0, 30)); newFence1.transform.Rotate(0, 90, 0);
        GameObject newFence2 = Instantiate(fence, transform, false); newFence2.name = string.Format("newFence2");
        newFence2.transform.Translate(new Vector3(-14, 0, 60)); newFence2.transform.Rotate(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
