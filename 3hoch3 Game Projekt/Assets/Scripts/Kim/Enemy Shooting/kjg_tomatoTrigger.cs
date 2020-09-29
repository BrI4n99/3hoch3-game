using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_tomatoTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            Debug.Log("Schaf getroffen");
            Destroy(gameObject);
        }
        
    }
}
