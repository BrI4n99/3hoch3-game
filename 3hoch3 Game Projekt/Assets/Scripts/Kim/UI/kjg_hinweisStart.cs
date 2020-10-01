using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class kjg_hinweisStart : MonoBehaviour
{
    public GameObject signStart;
    private bool signActivate;
    private float zeit;
    private float zeitClose;
    private bool schildSteht = false;

    void Start()
    {
        signStart.SetActive(false);
        signActivate = true;
    }

    public void closeSign() {
        signStart.SetActive(false);
        signActivate = false;
    }
 
    void Update()
    {
       zeit += Time.deltaTime;

       
       if (zeit > 5 && signActivate && !kjg_sceneChanger.warDraussen)
        {
            signStart.SetActive(true);
            schildSteht = true;
        }

        if (schildSteht) {
            zeitClose += Time.deltaTime;

            if (zeitClose > 6) {
                signStart.SetActive(false);
            }
        }

            
    }
}
