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
    Vector3 actPlayerPos;

    public static int[] hindernisseArr = new int[4];

    public static int k = 0;
    public static int randHind = -1;
    public static int randHeu = -1;
    public static int randEgg = -1;


    public GameObject myGameObject;

    public GameObject ground;
    public GameObject fence;
    public GameObject fence2;

    public float posZ = 0;

    public static int randHeuLang = -1;
    public static int randHindernis = -1;
    public static int randEggs = -1;
    public static int randHeuKurz = -1;

    private float posZstart = 360;


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
        actPlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
  
       // Spielerposition 
       if (counter >= maxAbsch) return;

       if ((aktPosZ - playerPos.position.z) <= len) 
       {
            if (counter == maxAbsch-1) 
            {
                neuerAbschnitt(ende) ;
            }
            else
            {
                neuerAbschnitt(haupt);
            }
            Destroy(transform.GetChild(0).gameObject);
            GameObject fence = Instantiate(zaun, Vector3.forward * (aktPosZ - (360 * 3)), Quaternion.identity) ;
            fence.transform.Rotate(0, 270, 0);
            fence.transform.position = new Vector3(-5, 0, aktPosZ - (360 * 3));
        }

        if (actPlayerPos.z > 1200) {
            Destroy(GameObject.FindGameObjectWithTag("ib_endGround"));
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
    }

   

}