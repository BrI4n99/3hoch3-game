using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_kiste : MonoBehaviour
{
    GameObject fass;
    Rigidbody kisteRigidbody;
    float flyingSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        fass = GameObject.FindWithTag("fassRollen");
        kisteRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fass) {
            Debug.Log("Kiste zerstören");
            kisteRigidbody.AddForce(kisteRigidbody.transform.up * flyingSpeed);

            Destroy(gameObject, 1f);
        }
    }
   
}
