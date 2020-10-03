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

        float[] hoehe =  { 1.3f, 1.7f, 1.8f, 2.1f, 1.4f, 1.6f};
        egg1.transform.Translate(Vector3.up * hoehe[Random.Range(0, 5)]);
        egg2.transform.Translate(Vector3.up * hoehe[Random.Range(0, 5)]);
        egg3.transform.Translate(Vector3.up * hoehe[Random.Range(0, 5)]);

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


        yield return new WaitForSeconds(2.2f);
        if (egg1 != null)
        {
            egg1.GetComponent<Rigidbody>().isKinematic = false;
            egg1.GetComponent<Rigidbody>().useGravity = true;
        }
        yield return new WaitForSeconds(3.3f);
        if (egg2 != null)
        {
            egg2.GetComponent<Rigidbody>().isKinematic = false;
            egg2.GetComponent<Rigidbody>().useGravity = true;
        }
        yield return new WaitForSeconds(4.25f);
        if (egg3 != null)
        {
            egg3.GetComponent<Rigidbody>().isKinematic = false;
            egg3.GetComponent<Rigidbody>().useGravity = true;
        }

    }


}
