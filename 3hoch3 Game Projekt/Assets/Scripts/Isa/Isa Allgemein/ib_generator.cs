using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_generator : MonoBehaviour
{
    public GameObject anfang; 
    public GameObject haupt; 
    public GameObject ende;
    public GameObject zaun; 
    public int erstes = 0;

    private const float len = 360f;  // Abschnittslänge
    private const float lenStart = 180f;
    private float aktPosZ = 0f;
    private const int maxAbsch = 4;
    private int counter = 0;

    public Transform playerPos;

    public static int[] hindernisseArr = new int[4];
    public static int[] heuLangArr = new int[4];
    public static int[] eggDuckArr = new int[4];

    private int k = 0;
    public static int randHind = -1;
    public static int randHeu = -1;
    public static int randEgg = -1;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        neuerAbschnitt(anfang); 
        anfang.transform.position = new Vector3(0, 0, 180);
        neuerAbschnitt(haupt);  
        neuerAbschnitt(haupt); 
    }

    // Update is called once per frame
    void Update()
    {
       // Spielerposition 
       if (counter >= maxAbsch) return;

       if ((aktPosZ - playerPos.position.z) <= len) 
       {
            if (counter == maxAbsch-1) 
            {
                neuerAbschnitt(ende);
            }
            else
            {
                neuerAbschnitt(haupt);
                
    
            }
             Destroy(transform.GetChild(0).gameObject);
            Instantiate(zaun, Vector3.forward * (aktPosZ - (360 * 3)), Quaternion.identity) ;
        }

    }


    void neuerAbschnitt(GameObject zuErzeugen) 
    {
        GameObject dieses = Instantiate(zuErzeugen, Vector3.forward * aktPosZ, Quaternion.identity); 
        dieses.transform.parent = transform;
      
      if (erstes == 0) 
        {
           aktPosZ += lenStart;
           erstes++;
        } else {
            aktPosZ += len;
            counter++;
       }
        if (zuErzeugen.name.Equals("haupt")) {
            hindernisseArr[k] = randHind;
            heuLangArr[k] = randHeu;
            eggDuckArr[k] = randEgg;
            k++;
        }

    }
}


