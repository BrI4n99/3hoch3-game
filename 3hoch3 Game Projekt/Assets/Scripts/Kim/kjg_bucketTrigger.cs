using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_bucketTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "boden")
        {
            Destroy(gameObject);
            Debug.Log("fallingObject zerstört");
        }
    }
}
