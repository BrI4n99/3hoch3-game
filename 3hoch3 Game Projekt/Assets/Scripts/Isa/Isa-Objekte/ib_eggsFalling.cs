using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_eggsFalling : MonoBehaviour
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
            StartCoroutine(falling());
        }
    }

    IEnumerator falling() {


        yield return new WaitForSeconds(3.5f);
        if (egg1 != null)
        {
            egg1.GetComponent<Rigidbody>().isKinematic = false;
            egg1.GetComponent<Rigidbody>().useGravity = true;
        }
        yield return new WaitForSeconds(4.5f);
        if (egg2 != null)
        {
            egg2.GetComponent<Rigidbody>().isKinematic = false;
            egg2.GetComponent<Rigidbody>().useGravity = true;
        }
        yield return new WaitForSeconds(6);
        if (egg3 != null)
        {
            egg3.GetComponent<Rigidbody>().isKinematic = false;
            egg3.GetComponent<Rigidbody>().useGravity = true;
        }

    }


}
