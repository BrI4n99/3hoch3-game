using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_Datenspeicher : MonoBehaviour
{
    public static ib_Datenspeicher DATEN; //this line will give you access to this script without the ned of getcomponent. 
    public static ib_Datenspeicher Instance;


    void Awake()
    {
        Instance = this;

        if (DATEN == null)
        {
            DontDestroyOnLoad(gameObject);
            DATEN = this;
        }
        else if (DATEN != this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame


     public void setLevel1Values()
        {
            ib_StaticVar._score = 1000;
            ib_StaticVar._startLives = 1;
            ib_StaticVar._carrots = 0;
            ib_StaticVar._eggs = 0;
            ib_StaticVar._deads = 0;
            ib_StaticVar._lives = 0;

            ib_StaticVar.sheep0 = true;
            ib_StaticVar.sheep1 = false;
            ib_StaticVar.sheep2 = false;
            ib_StaticVar.sheep3 = false;

            ib_StaticVar.mainPartCounter = 0;

            for (int i = 0; i < 3; i++)
            {
                ib_StaticVar.heuLang[i] = -1;
                ib_StaticVar.heuKurz[i] = -1;
                ib_StaticVar.hindernis[i] = -1;
                ib_StaticVar.eier[i] = -1;
            }

           
        }

        public void setLevel2Values()
    {
        ib_StaticVar._score = 500;
        ib_StaticVar._carrots = 0;
        ib_StaticVar._eggs = 12;
        ib_StaticVar._deads = 0;
        ib_StaticVar._lives = 2;

        ib_StaticVar.sheep0 = true;
        ib_StaticVar.sheep1 = false;
        ib_StaticVar.sheep2 = false;
        ib_StaticVar.sheep3 = false;

        // sheepStartPos = new Vector3(-24, 5, -23.5f);
    }
}
