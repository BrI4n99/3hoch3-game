using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tl_egg : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        print(collision);
        //StartCoroutine(DeactivateEgg());
        gameObject.SetActive(false);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    IEnumerator DeactivateEgg()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
