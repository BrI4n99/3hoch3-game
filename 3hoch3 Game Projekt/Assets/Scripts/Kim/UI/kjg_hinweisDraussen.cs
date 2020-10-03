using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kjg_hinweisDraussen : MonoBehaviour
{
    public GameObject signDraussen;
    private bool signActivate;
    private float zeit;
    private float zeitClose;
    private bool schildSteht = false;

    void Start()
    {
        signDraussen.SetActive(true);
        schildSteht = true;
    }

    public void closeSign()
    {
        signDraussen.SetActive(false);
        signActivate = false;
        SceneManager.LoadScene("kjg-szene");
    }

    void Update()
    {

        if (schildSteht)
        {
            zeitClose += Time.deltaTime;

            if (zeitClose > 6)
            {
                signDraussen.SetActive(false);
                
            }
        }


    }
}
