using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class kjg_key : MonoBehaviour
{
    public GameObject keys;
    public GameObject lightKey1;
    public GameObject lightKey2;
    public GameObject keyAnzeige;
    public static bool hasKey;
    bool floatUp;
   
    private void Start()
    {
        hasKey = true;
        gameObject.SetActive(false);
        floatUp = false;
        if (hasKey && kjg_sceneChanger.warDraussen) {
            Destroy(lightKey1);
            Destroy(lightKey2);
            gameObject.SetActive(false);
        }
    }

    //Schlüssel einsammeln
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            hasKey = true;
            //Punkte sammeln
            ib_StaticVar._score += 200;
            ib_StaticVar.level2 = true;
            Debug.Log("newScore = " + ib_StaticVar._score);

            //Key auf Canvas anzeigen
            keyAnzeige.SetActive(true);

            //Audio
            GetComponent<AudioSource>().Play();

            //Unsichtbar machen
            this.GetComponent<Renderer>().enabled = false;

            
            Debug.Log("Du hast den Schlüssel gesammelt! " + hasKey);
        }
    }

    //Floating Methoden
    IEnumerator floatingUp() {
        keys.transform.position += new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(0.5f);
        floatUp = false;
    }

    IEnumerator floatingDown()
    {
        keys.transform.position -= new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(0.5f);
        floatUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Hovering / Floating
        if (floatUp)
        {
            StartCoroutine(floatingUp());
        }
        else {
            StartCoroutine(floatingDown());
        }

        //Drehen
        this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 90f * Time.deltaTime);

        //Lampen entfernen
        if (hasKey) {
            Destroy(lightKey1);
            Destroy(lightKey2);
        }
    }
}
