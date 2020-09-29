using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_triggerShooting : MonoBehaviour
{
    public static bool shootTrigger;
    public GameObject kiste;

    private void Start()
    {
        if (kjg_sceneChanger.warDraussen) {
            shootTrigger = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            shootTrigger = true;  
        }        
    }
}
