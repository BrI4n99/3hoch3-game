﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_HinweisWasser : MonoBehaviour
{
    public Canvas canvas;
    Image sign;


    public static float hoch = 0;//Screen.height / 1.75F;
    public static float picHeight = 0;
    public static float height = 0;

    private bool touch;
    // Start is called before the first frame update
    void Start()
    {

        canvas = GameObject.FindGameObjectWithTag("ib_HinweisCarrot").GetComponent<Canvas>();
        sign = canvas.transform.GetChild(7).GetComponent<Image>();
        picHeight = sign.sprite.rect.height;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;

        Vector2 canvasScale = new Vector2(canvas.transform.localScale.x, canvas.transform.localScale.y);

        Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);
        hoch = (finalScale.x - picHeight * canvasScale.x * 1.2f);
    }


    public void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            if (touch != true)
            {
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

}
