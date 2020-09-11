﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ib_flyingEggs : MonoBehaviour
{

    public float randTime ;
    public float orientation;

    bool eggHit;
    bool touch;

    public static int eggCounter = 0;

    public AudioClip ching;
  
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Karotte animieren: drehen --------------------------------------------
   
        this.transform.RotateAround(this.transform.position, new Vector3(0, orientation, 0), randTime * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ib_CollCarrots")
        {
            if (!eggHit)
            {
               
                AudioSource.PlayClipAtPoint(ching, transform.position);
                eggCounter += 4;
                Debug.Log("Eieieeieieiei!");
                Destroy(gameObject);
                eggHit = true;
                touch = true;

               
            }
        }

    }
}