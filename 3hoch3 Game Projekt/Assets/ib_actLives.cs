using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_actLives : MonoBehaviour
{
    // private bool startGame;
    private int actLives;
    public Text actLivesText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // startGame = ib_LevelUI.start;

        actLives = 1 + ib_LevelUI.leben;
        actLivesText.text = "" + actLives;
    }
}
