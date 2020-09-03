using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_CheckBox_rollBarr : MonoBehaviour
{

    public GameObject barrel1;
    public GameObject barrel2;
    public GameObject barrel3;
    Rigidbody rigidbody1;
    Rigidbody rigidbody2;
    Rigidbody rigidbody3;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = barrel1.GetComponent<Rigidbody>();
        rigidbody2 = barrel2.GetComponent<Rigidbody>();
        rigidbody3 = barrel3.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
         Debug.Log("test touch checkbox");
        if (other.gameObject.tag == "Player") {
            
        barrel1.gameObject.SetActive(true); 
        barrel2.gameObject.SetActive(true);
        barrel3.gameObject.SetActive(true);
        rigidbody1.useGravity = true; 
        rigidbody2.useGravity = true;
        rigidbody3.useGravity = true;


        }
    }

}



