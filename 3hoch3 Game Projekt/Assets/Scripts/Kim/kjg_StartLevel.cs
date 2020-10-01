using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_StartLevel : MonoBehaviour
{
    //Objekte Scheune
    public GameObject wand;
    public GameObject tomatenKiste;
    public GameObject dach1;
    public GameObject dach2;
    public GameObject seite;
    public GameObject gefaengnis;

    //Tiere
    public GameObject schwein;
    public GameObject kuh;
    public GameObject huhn;

    //Eier & Möhren
    public GameObject eier;
    public GameObject moehren;

    //UI
    public GameObject keyAnzeige;

    //Hindernisse & Objekte
    public GameObject kiste;
    public GameObject fass;
    public GameObject keys;
    public GameObject fassKey;

    void Start()
    {
        keyAnzeige.SetActive(false);

        //-------------------------------------------WÄNDE--------------------------------------------------------
        Instantiate(wand);
        Instantiate(wand, new Vector3(25,3,50),Quaternion.Euler(new Vector3(0,180,0)));
        Instantiate(wand, new Vector3(50, 3, 25), Quaternion.Euler(new Vector3(0, 270, 0)));
        Instantiate(wand, new Vector3(0, 3, 25), Quaternion.Euler(new Vector3(0, 90, 0)));

        //---------------------------COROUTINES FÜR ANDERE OBJEKTE-----------------------------------------------
        StartCoroutine(activateTiere(kuh));
        StartCoroutine(activateTiere(schwein));
        StartCoroutine(activateTiere(huhn));
        StartCoroutine(activateGefaengnis(gefaengnis));
        StartCoroutine(activateKey(fassKey));
        if (!kjg_sceneChanger.warDraussen) {
            StartCoroutine(activateKey(keys));
        }
        StartCoroutine(activateOtherObjects());


    }
    //--------------------------TIERE------------------------------------
    IEnumerator activateTiere(GameObject tierObject)
    {
        yield return new WaitForSeconds(5f);
        tierObject.SetActive(true);
    }

    //----------------TOMATENKISTEN, PYRAMIDE, FASS, BÜNDEL-------------------------------
    IEnumerator activateOtherObjects()
    {
        yield return new WaitForSeconds(5f);
        //----------------------------------------TOMATENKISTEN---------------------------------------------------

        Instantiate(tomatenKiste, new Vector3(49.8f, 0.6f, 30f), Quaternion.Euler(new Vector3(-26.4f, 90, 0)));
        Instantiate(tomatenKiste, new Vector3(49.8f, 0.2f, 30f), Quaternion.Euler(new Vector3(0, 90, 0)));

        Instantiate(tomatenKiste, new Vector3(49.8f, 0.6f, 40.8f), Quaternion.Euler(new Vector3(-26.4f, 90, 0)));
        Instantiate(tomatenKiste, new Vector3(49.8f, 0.2f, 40.8f), Quaternion.Euler(new Vector3(0, 90, 0)));

        Instantiate(tomatenKiste, new Vector3(39.2f, 0.6f, 33.5f), Quaternion.Euler(new Vector3(-26.4f, -90, 0)));
        Instantiate(tomatenKiste, new Vector3(39.2f, 0.2f, 33.5f), Quaternion.Euler(new Vector3(0, -90, 0)));

        Instantiate(tomatenKiste, new Vector3(35, 0.6f, 44), Quaternion.Euler(new Vector3(-26.4f, 0, 0)));
        Instantiate(tomatenKiste, new Vector3(35, 0.2f, 44), Quaternion.identity);

        //------------------------------------------PYRAMIDE------------------------------------------------------
        //1.Reihe
        Instantiate(kiste, new Vector3(12, 0.5f, 19.5f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 0.5f, 18.5f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 0.5f, 17.5f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 0.5f, 16.5f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 0.5f, 15.5f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 0.5f, 14.5f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 0.5f, 13.5f), Quaternion.identity);

        //2. Reihe
        Instantiate(kiste, new Vector3(12, 1.5f, 19f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 1.5f, 18f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 1.5f, 17f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 1.5f, 16f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 1.5f, 15f), Quaternion.identity);
        Instantiate(kiste, new Vector3(12, 1.5f, 14f), Quaternion.identity);

        //--------------------------------------------FASS---------------------------------------------------------

        Instantiate(fass, new Vector3(5.5f, 1.1f, 16), Quaternion.Euler(new Vector3(90, 0, 0)));

        //-------------------------------------------MÖHREN--------------------------------------------------------
        moehren.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Instantiate(moehren, new Vector3(20, 0, 16), Quaternion.Euler(new Vector3(0, 180, 0)));
    }

    //---------------------TÜR GEFÄNGNIS--------------------------------
    IEnumerator activateGefaengnis(GameObject otherObject)
    {
        yield return new WaitForSeconds(3f);
        otherObject.SetActive(true);
    }

    //--------------------------KEY & FASS------------------------------
    IEnumerator activateKey(GameObject otherObject) {
        yield return new WaitForSeconds(0.7f);
        otherObject.SetActive(true);
    }


}
