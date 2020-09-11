using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ib_LevelUI : MonoBehaviour
{
    public static int collectedCarrots;
    public static int score;
    public static bool start = true;
    public static int leben;
    private int tode;

    public static bool sheep0;
    public static bool sheep1;
    public static bool sheep2;
    public static bool sheep3;
    public bool checkNextLevel;

    public static int eggs;
    public static int sizePointArr = 50;
    public int[] points = new int[sizePointArr];

    public GameObject looseScreen;
    public GameObject nextLevelScreen;

    // public int fontSize1 = 42;
    // public Color colorFont1 = Color.white;


    // Start is called before the first frame update
    void Start()
    {
        looseScreen.SetActive(false);

        leben = 1;
        eggs = 0;
        score = 1000; 

        int teilpunkte = 0;
        for (int i = 0; i < sizePointArr; i++)
        {
            teilpunkte = teilpunkte + points[i];
        }
        score = 1000 + teilpunkte;

        if (start)
        {
            looseScreen.SetActive(false);
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

        if (leben < 0)
        {
           
            SceneManager.LoadScene("ib_loose");
           
        }
        checkNextLevel = ib_nextLevel.nextLevel;
        


        if (checkNextLevel)
        {
            checkNextLevel = false;
            leben = 1;
            SceneManager.LoadScene("ib_nextLevel2");
            
        }
        checkNextLevel = false;

        eggs = ib_egg.eggCount + ib_flyingEggs.eggCounter;


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

        public void doExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; // später löschen
        Application.Quit();
    }



}





   

   




