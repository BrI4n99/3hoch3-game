using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_carrot : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        

     // Karotte animieren, hüpfen

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "SheepWhite") {
            Destroy(gameObject);
            // Karotte löschen
            // Punkte zählen
        }
        
    }

}
