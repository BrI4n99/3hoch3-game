using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_fass : MonoBehaviour
{
    GameObject sheep;
    Rigidbody fassRigidbody;
    private float rollenSpeed = 1000;
    private int countPlay;
    // Start is called before the first frame update
    void Start()
    {
        sheep = GameObject.Find("SheepWhite");
        fassRigidbody = gameObject.GetComponent<Rigidbody>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            Debug.Log("rollenasdfasdf");
            countPlay++;
            fassRigidbody.AddForce(sheep.transform.forward * rollenSpeed);
            if (countPlay == 1) {
                GetComponent<AudioSource>().Play();
            }
            
        }
    }

}
