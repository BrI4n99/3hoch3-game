using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_buendel : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            GetComponent<AudioSource>().Play();
            ib_StaticVar._lives += 1;
            gameObject.SetActive(false);
        }
    }
}
