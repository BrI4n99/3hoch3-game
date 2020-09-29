using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_schafDraussen : MonoBehaviour
{
    public GameObject keys;
   
    void Start()
    {
        //Überprüfen, ob Schaf schon draußen war und ob es schon die Schlüssel hat, denn wenn die Tiere schon befreit wurden, soll kein neuer Schlüssel auftauchen
        if (kjg_sceneChanger.warDraussen == true) {
            Debug.Log("wieder drinnen");
            
            if (kjg_key.hasKey == true) {
                Destroy(keys);
            }
        }
    }
}
