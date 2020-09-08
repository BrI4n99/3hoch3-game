using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_tuer : MonoBehaviour
{
    public GameObject keys;
    public GameObject tuer;
    public static bool offen;
        
    [SerializeField]
    kjg_key keyScript;


    IEnumerator tuerAuf() {
        while(tuer.transform.position.y <= 3.5f)
        {
            tuer.transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.1f);

        }
        
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "SheepWhite" && kjg_key.hasKey) {
            StartCoroutine(tuerAuf());
            offen = true;
        }
    }
    
}
