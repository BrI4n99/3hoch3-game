using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_GUI : MonoBehaviour
{
    public static int collectedCarrots; 
    public static int score = 1000;
    public static bool start = true;
     public static int leben;
     private int tode;

    
    public static int eggs = 0;
    public static int sizePointArr = 50;
    public int[] points = new int[sizePointArr];

    public int fontSize1 = 42;
    public Color colorFont1 = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < sizePointArr; i++) {
           
       // }
       
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("GUI UPDATE");
        collectedCarrots = ib_carrot.carrots; 
        leben = (ib_carrot.carrots / 4) - ib_rollingBarrel.sterben;
        points[0] =  (ib_rollingThing.bonus);
        points[1] =  (ib_hayBale.minuspunkte);
        points[2] =  (ib_hayBaleVar.minuspunkte);
        points[3] =  (ib_fenceVar.minuspunkte);
        points[4] =  (ib_fence.minuspunkte);
        points[5] = (ib_button.bonuspunkte);
        points[6] = (ib_duck.minuspunkte);

        eggs = ib_egg.eggCount;
        
    }

void OnGUI() 
    {
       // Debug.Log("GUI ONGUI");
        int teilpunkte = 0;
        for (int i = 0; i < sizePointArr; i++) {
            teilpunkte = teilpunkte + points[i];
        }
        score = 1000 + teilpunkte;

        if (start) {
            leben += 1;
            start = false;
        }   

        GUIStyle styleCarrots = new GUIStyle();
        styleCarrots.fontSize = fontSize1;
        styleCarrots.normal.textColor = colorFont1;
        
        GUI.Label(new Rect(10, 0, 0, 0), "Leben: " + leben  + " (Möhren: " + collectedCarrots % 4 + ")", styleCarrots);
       
        
        GUIStyle styleScore = new GUIStyle();
        styleScore.fontSize = fontSize1;
        styleScore.normal.textColor = colorFont1;
        GUI.Label(new Rect(500, 0, 0, 0), "Punkte: " + score, styleScore);

        GUIStyle styleEggs = new GUIStyle();
        styleEggs.fontSize = fontSize1;
        styleEggs.normal.textColor = colorFont1;
        GUI.Label(new Rect(800, 0, 0, 0), "Eier: " + eggs , styleScore);

        if (leben < 0) {
            GUIStyle gameOver = new GUIStyle();
            gameOver.fontSize = fontSize1;
            gameOver.normal.textColor = colorFont1;
            GUI.Label(new Rect(500, 500, 0, 0), "You died. GAME OVER!", styleScore);
        }
    }

}
