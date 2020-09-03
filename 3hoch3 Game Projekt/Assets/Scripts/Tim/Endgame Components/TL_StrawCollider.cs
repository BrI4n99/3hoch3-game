using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_StrawCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "StrawBale")
        {
            other.gameObject.SetActive(false);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
