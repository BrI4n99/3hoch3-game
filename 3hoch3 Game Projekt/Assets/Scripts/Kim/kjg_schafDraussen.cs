using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_schafDraussen : MonoBehaviour
{
    //public GameObject cam;
    //public GameObject sheep;
    public GameObject keys;
    // Start is called before the first frame update
    void Start()
    {
        if (kjg_draussen_drinnen.warDraussen == true) {
            Debug.Log("wieder drinnen");
            this.transform.position = new Vector3(2,0,17);
            if (kjg_key.hasKey == true) {
                Destroy(keys);
            }
           
            //cam.transform.position = new Vector3(2,0,17);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
