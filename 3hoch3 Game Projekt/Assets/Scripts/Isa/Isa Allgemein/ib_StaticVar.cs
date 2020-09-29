using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ib_StaticVar : MonoBehaviour
{
   // public static ib_StaticVar DATEN;

    public static int _score;
    public static int _lives;
    public static int _startLives;
    public static int _carrots;
    public static int _eggs;
    public static int _deads;
    public static int _bonus;


    public static bool sheep0;
    public static bool sheep1;
    public static bool sheep2;
    public static bool sheep3;


    public static int mainPartCounter;
    public static Vector3 sheepStartPos;

    public static int[] heuLang = new int[3];
    public static int[] heuKurz = new int[3];
    public static int[] eier = new int[3];
    public static int[] hindernis = new int[3];

    public static bool level1 = false;
    public static bool level2 = false;

    #region Singleton                                       
    public static ib_StaticVar Instance;                                     // Methodenaufrufe in anderen Scripts möglich

    private void Awake()
    {
        Instance = this;
        level1 = true;

           /* if (DATEN == null)
            {
                DontDestroyOnLoad(gameObject);
                DATEN = this;
            }
            else if (DATEN != this)
            {
                Destroy(gameObject);
            }*/
       
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
      
        setLevel1Values();


    }

    private void Update()
    {

        _lives = _startLives + (_carrots / 3) - _deads;

        if (_carrots == 0)
        {

            sheep0 = true;
            sheep1 = false; sheep2 = false; sheep3 = false;
        }
        else
        {
            

            if (_carrots % 3 <= 1)
            {
                sheep1 = true;
                sheep0 = false; sheep2 = false; sheep3 = false;
            }
            
            if (_carrots % 3 == 2)
            {
                sheep2 = true;
                sheep0 = false; sheep1 = false; sheep3 = false;
            }
            if (_carrots % 3 == 0)
            {
                sheep3 = true;
                sheep0 = false; sheep1 = false; sheep2 = false;
            }
        }


        if (_lives <= 0 || _score <= 0) {
            SceneManager.LoadScene("ib_loose");
        }



            
    }

    public void setLevel1Values()
    {
        _score = 500;
        _startLives = 1;
        _carrots = 0;
        _eggs = 0;
        _deads = 0;
        _lives = 0;
        _bonus = 250;

        sheep0 = true;
        sheep1 = false;
        sheep2 = false;
        sheep3 = false;

        mainPartCounter = 0;

        for (int i = 0; i < 3; i++) {
            heuLang[i] = -1;
            heuKurz[i] = -1;
            hindernis[i] = -1;
            eier[i] = -1;
        }

        // sheepStartPos = new Vector3(-24, 5, -23.5f);
    }


    public void setLevel2Values()
    {
        _score = 500;
        _startLives = 1;
        _carrots = 0;
        _eggs = 12;
        _deads = 0;
        _lives = 0;

        sheep0 = true;
        sheep1 = false;
        sheep2 = false;
        sheep3 = false;

        // sheepStartPos = new Vector3(-24, 5, -23.5f);
    }
}
