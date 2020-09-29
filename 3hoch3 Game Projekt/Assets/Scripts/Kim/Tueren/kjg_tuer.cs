using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_tuer : MonoBehaviour
{
    public GameObject tuer;
    public static bool offen;
    public GameObject signGefaengnis;
    public GameObject keyAnzeige;
    private bool activate;
    private bool schildSteht = false;
    float zeit;
  
    //Tür zu den Tieren öffnen
    private void Start()
    {
        signGefaengnis.SetActive(false);
        activate = true;
    }

    public void closeSign()
    {
        signGefaengnis.SetActive(false);
        activate = false;
    }
    IEnumerator tuerAuf() {
        while(tuer.transform.position.y <= 3.5f)
        {
            tuer.transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "SheepWhite" && kjg_key.hasKey)
        {
            //Punkte
            ib_StaticVar._score += 200;

            //Anzeige Schlüssel
            keyAnzeige.SetActive(false);

            StartCoroutine(tuerAuf());
            offen = true;
        }
        else if (other.gameObject.name == "SheepWhite" && activate)
        {
            signGefaengnis.SetActive(true);
            schildSteht = true;
        }
    }
    private void Update()
    {
        if (schildSteht)
        {
            zeit += Time.deltaTime;
            if (zeit > 4)
            {
                signGefaengnis.SetActive(false);
            }
        }
    }
}
