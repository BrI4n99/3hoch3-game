﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_actLives : MonoBehaviour
{
    ib_LevelUI UI;
    // private bool startGame;
    // private int actLives;
    public Text actLivesText;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // startGame = ib_LevelUI.start;
        /*
        actLives = ib_LevelUI.leben;
        actLivesText.text = "" + actLives;
        */


        

  
        


        actLivesText.text = "" + ib_StaticVar._lives;
    }
}
