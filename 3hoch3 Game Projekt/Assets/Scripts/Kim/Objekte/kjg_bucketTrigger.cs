using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_bucketTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "boden")
        {
            Destroy(gameObject, 0.5f);
            Debug.Log("fallingObject zerstört");
        }

        if (other.gameObject.name == "SheepWhite") {
            ib_StaticVar._score -= 100;
        }
    }
}
