using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kjg_tuerDraussen : MonoBehaviour
{
    //Szenenwechesl von drinnen nach draußen

    public GameObject signTuerDraussen;
    private bool activate;
    private bool schildSteht = false;
    float zeit;
    private void Start()
    {
        signTuerDraussen.SetActive(false);
        activate = true;
    }

    public void closeSign()
    {
        signTuerDraussen.SetActive(false);
        activate = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite" && kjg_tiereVorTuer.kuhVorTuer && kjg_tiereVorTuer.schweinVorTuer && kjg_huhn2.hasHuhn)
        {
            SceneManager.LoadScene("kjg-draussen2");
        }
        else if (other.gameObject.name == "SheepWhite" && activate)
        {
            signTuerDraussen.SetActive(true);
            schildSteht = true;
        }
    }

    private void Update()
    {
        if (schildSteht) {
            zeit += Time.deltaTime;
            if (zeit > 4) {
                signTuerDraussen.SetActive(false);
            }
        }
    }

}
