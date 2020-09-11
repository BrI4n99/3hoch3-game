using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_eggsEnd : MonoBehaviour
{
    public GameObject egg1;
    public GameObject egg2;
    public GameObject egg3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(egg1);
            Destroy(egg2);
            Destroy(egg3);

        }
    }

}
