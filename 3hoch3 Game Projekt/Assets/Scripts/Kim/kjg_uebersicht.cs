using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_uebersicht : MonoBehaviour
{
    public GameObject timeline;
    public GameObject cameraUebersicht;

    //Übersicht über Labyrinth geben

    void Start()
    {
        if (kjg_sceneChanger.warDraussen == true) {
           timeline.SetActive(false);
            cameraUebersicht.SetActive(false);
        }
    }

    void Update()
    {
        //Kamera 60° an der Y-Achse drehen, damit gesamte Scheune gezeigt wird
        if(this.transform.rotation.y <= 14.0f)
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 10f * Time.deltaTime);
        }
    }
}
