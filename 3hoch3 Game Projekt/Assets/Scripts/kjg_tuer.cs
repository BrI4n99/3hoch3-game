using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_tuer : MonoBehaviour
{
    public GameObject keys;
    public GameObject tuer;
    
    [SerializeField]
    kjg_key keyScript;
    bool hasKey;
    //Zugriff auf kjg_key
    //kjg_key keyScript = keys.GetComponent<kjg_key>();

    void Start() {
        hasKey = keyScript.hasKey;

        if (hasKey) {
            Debug.Log("JUHUUUUUUU " + hasKey);
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "SheepWhite") {
            while (tuer.transform.position.y <= 3.5f) {
                tuer.transform.position += new Vector3(0, 1.5f * Time.deltaTime, 0);
            }
        }
    }
}
