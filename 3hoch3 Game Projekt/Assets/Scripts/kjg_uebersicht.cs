using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_uebersicht : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Kamera 60° an der Y-Achse drehen, damit gesamte Scheune gezeigt wird
        if(this.transform.rotation.y <= 14.0f)
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), -10f * Time.deltaTime);
        }
    }
}
