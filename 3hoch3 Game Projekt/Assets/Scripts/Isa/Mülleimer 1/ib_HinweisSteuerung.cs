using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_HinweisSteuerung : MonoBehaviour
{
    public Canvas canvas;
    Image sign;
    bool abzug;
    int punkte;

    public static float hoch = 0;//Screen.height / 1.75F;
    public static float picHeight = 0;
    public static float height = 0;

    private bool touch;
    private bool go = true;
    // Start is called before the first frame update
    void Start()
    {

        sign = canvas.transform.GetChild(6).GetComponent<Image>();
        picHeight = sign.sprite.rect.height;

    }

    // Update is called once per frame
    void Update()
    {
        // Berechnungen über Distanz, die das Schild ins Bild bewegt wird (und abhängig von der Auflösung / Fenstergröße - nur anhand des Verhältnisses
        Vector2 sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;

        Vector2 canvasScale = new Vector2(canvas.transform.localScale.x, canvas.transform.localScale.y);

        Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);
        hoch = (finalScale.x - picHeight * canvasScale.x * 1.2f);

        punkte = ib_StaticVar._bonus;
        if (touch) {
            StartCoroutine(spielzeit());
        }

        if (abzug) {
           
            if (ib_StaticVar._bonus > 50 && go) {
                StartCoroutine(abziehen());
            }
        }
    }


    public void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            if (touch != true)
            {
                Debug.Log("Das Abenteuer geht los!");
                StartCoroutine(openSign());
                touch = true;
                StartCoroutine(closeSign());
              
                
            }

        }
    }
    public IEnumerator closeSign()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < hoch; i += 15)
        {
            sign.transform.Translate(new Vector3(0, -15, 0));
            yield return new WaitForSeconds(0.001f);
        }
    }

    public IEnumerator openSign()
    {
        for (int i = 0; i < hoch; i += 15)
        {
            sign.transform.Translate(new Vector3(0, 15, 0));
            yield return new WaitForSeconds(0.001f);

        }
    }

    public IEnumerator spielzeit()
    {
     
        yield return new WaitForSeconds(55f);
        abzug = true;
      
    }

    public IEnumerator abziehen()
    {
        go = false;    
        yield return new WaitForSeconds(1f);
        ib_StaticVar._bonus -= 1;
        go = true;
    }
}
