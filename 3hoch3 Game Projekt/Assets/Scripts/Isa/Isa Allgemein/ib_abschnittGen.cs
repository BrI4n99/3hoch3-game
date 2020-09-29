using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_abschnittGen : MonoBehaviour
{

    public GameObject ground;
    public GameObject fence;
    public GameObject fence2;

    public float posZ = 0;

    
    public List<GameObject> heuLangNeu; // 144
    public List<GameObject> heuKurzNeu; // 72
    public List<GameObject> hindernisNeu; // Pyramide und rollende Fässer // 72
    public List<GameObject> actionNeu; // Eier 72
    
    public static int randHeuLang = -1; 
    public static int randHindernis = -1;
    public static int randEgg = -1;
    public static int randHeuKurz = -1;

   

    private int counter;
    private int randSpeicher;


    #region Singleton

    public static ib_abschnittGen Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fence2, transform, false);
        Instantiate(fence, transform, false); // relativ zum Elternobjekt
        Instantiate(ground, transform, false);

        List<GameObject> aktElem = new List<GameObject>();

        randHeuLang = Random.Range(0, heuLangNeu.Count);
        randHeuKurz = Random.Range(0, heuKurzNeu.Count);
        randHindernis = Random.Range(0, hindernisNeu.Count);
        randEgg = Random.Range(0, actionNeu.Count);

        if (ib_StaticVar.mainPartCounter == 0)
        {
            ib_StaticVar.heuLang[0] = randHeuLang;
            Debug.Log("heulang[" + ib_StaticVar.mainPartCounter + "] ist gleich " + randHeuLang);
            ib_StaticVar.heuKurz[0] = randHeuKurz;
            ib_StaticVar.hindernis[0] = randHindernis;
            ib_StaticVar.eier[0] = randEgg;


        }

        else {

            for (int i = 0; i < ib_StaticVar.mainPartCounter; i++)
            {
                while (ib_StaticVar.heuLang[i] == randHeuLang) {
                    randHeuLang = Random.Range(0, heuLangNeu.Count);
                   
                }
                while (ib_StaticVar.heuKurz[i] == randHeuKurz)
                {
                    randHeuKurz = Random.Range(0, heuKurzNeu.Count);
                }
                while (ib_StaticVar.hindernis[i] == randHindernis)
                {
                    randHindernis = Random.Range(0, hindernisNeu.Count);
                }
                while (ib_StaticVar.eier[i] == randEgg)
                {
                    randEgg = Random.Range(0, actionNeu.Count);
                }
                ib_StaticVar.heuLang[ib_StaticVar.mainPartCounter] = randHeuLang;
                Debug.Log("heulang[" + ib_StaticVar.mainPartCounter + "] ist gleich " + randHeuLang);
                ib_StaticVar.heuKurz[ib_StaticVar.mainPartCounter] = randHeuKurz;
                ib_StaticVar.hindernis[ib_StaticVar.mainPartCounter] = randHindernis;
                ib_StaticVar.eier[ib_StaticVar.mainPartCounter] = randEgg;
            }
            

        }


        aktElem.Add(heuLangNeu[randHeuLang]);
        aktElem.Add(actionNeu[randEgg]);
        aktElem.Add(hindernisNeu[randHindernis]);
        aktElem.Add(heuKurzNeu[randHeuKurz]);     
        


        for (int i = 0; i < aktElem.Count; i++) {
            
            int randIndex1 = Random.Range(0,aktElem.Count);
                
            GameObject speicher = aktElem[randIndex1];
            aktElem[randIndex1] = aktElem[i];
            aktElem[i] = speicher; 
        }


        foreach (GameObject tempO in aktElem)
        {
            GameObject newObj = Instantiate(tempO, transform, false);
            float laengeObj = newObj.GetComponent<ib_abstandNR>().laenge; 
            newObj.transform.Translate(Vector3.forward * posZ);
            posZ += laengeObj;
        }

        ib_StaticVar.mainPartCounter++;
    }

    // Update is called once per frame
    void Update()
    {

       

        
    }
}

