using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_buttonExit : MonoBehaviour
{
    public Canvas hinweise;
    public Button tippsAus;
    public Button tippsEin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false; // später löschen
        Application.Quit();
        // Debug.Log("EXIT");
    }

    // Hinweise ein- und ausblenden
    public void closeTipps()
    {
        hinweise.gameObject.SetActive(false);
        tippsEin.gameObject.SetActive(true);
        tippsAus.gameObject.SetActive(false);
    }


    public void showTipps()
    {
        hinweise.gameObject.SetActive(true);
        tippsAus.gameObject.SetActive(true);
        tippsEin.gameObject.SetActive(false);
    }
}
