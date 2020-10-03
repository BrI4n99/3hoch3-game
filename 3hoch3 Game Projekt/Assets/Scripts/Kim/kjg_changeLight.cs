using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_changeLight : MonoBehaviour
{
    //Licht Tomatenkiste
    public GameObject tkl1;
    public GameObject tkl2;
    public GameObject tkl3;
    public GameObject tkl4;

    //Licht Gefängnis
    public GameObject gl1;
    public GameObject gl2;
    public GameObject gl3;

    //Licht Key
    public GameObject lK;

    //Spotlights
    public GameObject sl1;
    public GameObject sl2;
    public GameObject sl3;
    public GameObject sl4;
    public GameObject sl5;
    public GameObject sl6;
    public GameObject sl7;
    public GameObject sl8;


    //Volume
    public GameObject volume;

    float zeit;
    // Start is called before the first frame update
    void Start()
    {
        tkl1.SetActive(false);
        tkl2.SetActive(false);
        tkl3.SetActive(false);
        tkl4.SetActive(false);

        gl1.SetActive(false);
        gl2.SetActive(false);
        gl3.SetActive(false);

        lK.SetActive(false);

        volume.SetActive(false);

        sl1.SetActive(false);
        sl2.SetActive(false);
        sl3.SetActive(false);
        sl4.SetActive(false);
        sl5.SetActive(false);
        sl6.SetActive(false);
        sl7.SetActive(false);
        sl8.SetActive(false);
    }


    private void Update()
    {
        zeit += Time.deltaTime;
        if (zeit > 5f) {
            
            tkl1.SetActive(true);
            tkl2.SetActive(true);
            tkl3.SetActive(true);
            tkl4.SetActive(true);

            gl1.SetActive(true);
            gl2.SetActive(true);
            gl3.SetActive(true);

            lK.SetActive(true);

            volume.SetActive(true);

            sl1.SetActive(true);
            sl2.SetActive(true);
            sl3.SetActive(true);
            sl4.SetActive(true);
            sl5.SetActive(true);
            sl6.SetActive(true);
            sl7.SetActive(true);
            sl8.SetActive(false);
        }

    }
}
