using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_StartLevel : MonoBehaviour
{
    public GameObject wand;
    public GameObject kiste;
    //public GameObject boden;
    public GameObject gefaengnis;
    //public GameObject tuerDraussen;
    public GameObject dach1;
    public GameObject dach2;
    public GameObject seite;
    public GameObject keyAnzeige;

    float zeit;
    bool tuerGefaengnis;

    // Start is called before the first frame update
    void Start()
    {
        keyAnzeige.SetActive(false);
        tuerGefaengnis = false;
        Instantiate(wand);
        Instantiate(wand, new Vector3(25,3,50),Quaternion.Euler(new Vector3(0,180,0)));
        Instantiate(wand, new Vector3(50, 3, 25), Quaternion.Euler(new Vector3(0, 270, 0)));
        Instantiate(wand, new Vector3(0, 3, 25), Quaternion.Euler(new Vector3(0, 90, 0)));

        //Tomatenkisten
        //Tomatenkisten
        Instantiate(kiste, new Vector3(49.8f, 0.6f, 30f), Quaternion.Euler(new Vector3(-26.4f, 90, 0)));
        Instantiate(kiste, new Vector3(49.8f, 0.2f, 30f), Quaternion.Euler(new Vector3(0, 90, 0)));

        Instantiate(kiste, new Vector3(49.8f, 0.6f, 40.8f), Quaternion.Euler(new Vector3(-26.4f, 90, 0)));
        Instantiate(kiste, new Vector3(49.8f, 0.2f, 40.8f), Quaternion.Euler(new Vector3(0, 90, 0)));

        Instantiate(kiste, new Vector3(39.2f, 0.6f, 33.5f), Quaternion.Euler(new Vector3(-26.4f, -90, 0)));
        Instantiate(kiste, new Vector3(39.2f, 0.2f, 33.5f), Quaternion.Euler(new Vector3(0, -90, 0)));

        Instantiate(kiste, new Vector3(35, 0.6f, 44), Quaternion.Euler(new Vector3(-26.4f, 0, 0)));
        Instantiate(kiste, new Vector3(35, 0.2f, 44), Quaternion.identity);

        if (tuerGefaengnis) {
            Instantiate(gefaengnis);
        }
    }

    // Update is called once per frame
    void Update()
    {
        zeit += Time.deltaTime;
        if (zeit >= 4) {
            tuerGefaengnis = true;
        }
        
    }
}
