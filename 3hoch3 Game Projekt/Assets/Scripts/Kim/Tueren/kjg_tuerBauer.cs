using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kjg_tuerBauer : MonoBehaviour
{
    //Szenenwechsel Labyrinth - Endlevel

    public GameObject signTuerBauer;
    private bool activate;
    private bool schildSteht = false;
    float zeit;

    private void Start()
    {
        signTuerBauer.SetActive(false);
        activate = true;
    }

    public void closeSign()
    {
        signTuerBauer.SetActive(false);
        activate = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite" && kjg_sceneChanger.warDraussen == true)
        {
            SceneManager.LoadScene("ib_nextLevel3");
        }
        else if (other.gameObject.name == "SheepWhite" && activate)
        {
            signTuerBauer.SetActive(true);
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
                signTuerBauer.SetActive(false);
            }
        }
    }
}
