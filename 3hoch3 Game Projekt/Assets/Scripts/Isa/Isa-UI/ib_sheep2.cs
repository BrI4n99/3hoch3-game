﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_sheep2 : MonoBehaviour
{

  
    private bool showSheep2;
    public Image sheepPic2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showSheep2 = ib_LevelUI.sheep2;

        if (showSheep2)
        {
            sheepPic2.enabled = true;
        }
        else
        {
            sheepPic2.enabled = false;
        }

    }
}