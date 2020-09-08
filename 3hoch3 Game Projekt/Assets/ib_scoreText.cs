using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_scoreText : MonoBehaviour
{

    public Text scoreText;
    private int countPoints;

    public int teilpunkte;
    public int score = 1000;
    public static int sizePointArr = 50;
    public int[] points = new int[sizePointArr];

    // Start is called before the first frame update
    void Start()
    {
    
        teilpunkte = 1000;
    }

    // Update is called once per frame
    void Update()
    {

        points[0] = (ib_rollingThing.bonus);
        points[1] = (ib_hayBale.minuspunkte);
        points[2] = (ib_hayBaleVar.minuspunkte);
        points[3] = (ib_fenceVar.minuspunkte);
        points[4] = (ib_fence.minuspunkte);
        points[5] = (ib_button.bonuspunkte);
        points[6] = (ib_duck.minuspunkte);
        points[6] = (ib_trog.minuspunkte);

        teilpunkte = 0;
        for (int i = 0; i < sizePointArr; i++)
        {
            teilpunkte = teilpunkte + points[i];
        }

        score = 1000 + teilpunkte; 

        scoreText.text = "" + score;



    }
}
