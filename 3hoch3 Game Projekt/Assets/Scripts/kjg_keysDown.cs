using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class kjg_keysDown : MonoBehaviour
{

    public GameObject keys;

    void OnTriggerEnter(Collider other) {
        if (keys.transform.position.y >= 2.76f) {
            keys.transform.position = new Vector3(keys.transform.position.x, keys.transform.position.y - 3, keys.transform.position.z);

        }
    }
}
