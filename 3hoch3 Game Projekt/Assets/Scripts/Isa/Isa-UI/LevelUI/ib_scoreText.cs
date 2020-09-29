using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ib_scoreText : MonoBehaviour
{

    public Text scoreText;
    private int countPoints;

    public int teilpunkte;
    public int score = 1000;
    public static int sizePointArr = 50;
    public int[] points = new int[sizePointArr];


    public Image star;
    public Animator starZoom;

    public int tempPoints = ib_StaticVar._score;

   

    // Start is called before the first frame update
    void Start()
    {



        

        //starZoom = star.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
       // Debug.Log(currentScene.name);

       /* if (currentScene.name == "kjg-szene || kjg-draussen") {

            scoreText.text = "" + ib_Datenspeicher.score_;
            Debug.Log("Daten =" + ib_Datenspeicher.score_);
        }

        else
        {*/
            scoreText.text = "" + ib_StaticVar._score;
        //}
      
    }
}
