using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_LevelUI : MonoBehaviour
{
    public static int collectedCarrots;
    public static int score = 1000;
    public static bool start = true;
    public static int leben;
    private int tode;

    public static bool sheep0;
    public static bool sheep1;
    public static bool sheep2;
    public static bool sheep3;

    public static int eggs = 0;
    public static int sizePointArr = 50;
    public int[] points = new int[sizePointArr];

    // public int fontSize1 = 42;
    // public Color colorFont1 = Color.white;


    // Start is called before the first frame update
    void Start()
    {

        int teilpunkte = 0;
        for (int i = 0; i < sizePointArr; i++)
        {
            teilpunkte = teilpunkte + points[i];
        }
        score = 1000 + teilpunkte;

        if (start)
        {
            leben += 1;
            start = false;
        }


        /*        
        GUI.Label(new Rect(10, 0, 0, 0), "Leben: " + leben + " (Möhren: " + collectedCarrots % 4 + ")", styleCarrots);

        GUI.Label(new Rect(500, 0, 0, 0), "Punkte: " + score, styleScore);

        GUI.Label(new Rect(800, 0, 0, 0), "Eier: " + eggs, styleScore);

        if (leben < 0)
        {
            GUI.Label(new Rect(500, 500, 0, 0), "You died. GAME OVER!", styleScore);

        }*/

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("GUI UPDATE");
        collectedCarrots = ib_carrot.carrots;

        leben = (ib_carrot.carrots / 4) - ib_rollingBarrel.sterben;


      

        eggs = ib_egg.eggCount;


        if (collectedCarrots % 4 == 0)
        {
            sheep0 = true;
            sheep1 = false; sheep2 = false; sheep3 = false;
        }
        if (collectedCarrots % 4 == 1)
        {
            sheep1 = true;
            sheep0 = false; sheep2 = false; sheep3 = false;
        }
        if (collectedCarrots % 4 == 2)
        {
            sheep2 = true;
            sheep0 = false; sheep1 = false; sheep3 = false;
        }
        if (collectedCarrots % 4 == 3)
        {
            sheep3 = true;
            sheep0 = false; sheep1 = false; sheep2 = false;
        }
    }
}



/// <summary>
/// //////////
/// </summary>

   

   




