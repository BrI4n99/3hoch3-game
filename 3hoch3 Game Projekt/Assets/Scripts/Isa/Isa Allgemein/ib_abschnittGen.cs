using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_abschnittGen : MonoBehaviour
{

    ib_generator s1;

    public GameObject myGameObject;

    public GameObject ground;
    public GameObject fence;
    public GameObject fence2;

    public float posZ = 0;

    
    public List<GameObject> heuLangNeu; // 144
    public List<GameObject> heuKurzNeu; // 72
    public List<GameObject> hindernisNeu; // Pyramide und rollende Fässer // 72
    public List<GameObject> actionNeu; // Eier, Brunnen // 72
    


    public static int randHeuLang = -1; 
    public static int randHindernis = -1;
    public static int randEgg = -1;
    public static int randHeuKurz = -1;

    int hinternisNr;

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
       /* s1 = GetComponent<ib_generator>();
        heuLangNeu = myGameObject.GetComponent<ib_generator>().heuLang;
        heuKurzNeu = myGameObject.GetComponent<ib_generator>().heuKurz;
        hindernisNeu = myGameObject.GetComponent<ib_generator>().hindernis;
        actionNeu = myGameObject.GetComponent<ib_generator>().action;*/


        Instantiate(fence2, transform, false);
        Instantiate(fence, transform, false); // relativ zum Elternobjekt
        Instantiate(ground, transform, false);

        List<GameObject> aktElem = new List<GameObject>();

        randHeuLang = Random.Range(0, heuLangNeu.Count);
        randHindernis = Random.Range(0, hindernisNeu.Count);
        randEgg = Random.Range(0, actionNeu.Count);
        randHeuKurz = Random.Range(0, heuKurzNeu.Count);

        aktElem.Add(heuLangNeu[randHeuLang]);
        heuLangNeu.Remove(heuLangNeu[randHeuLang]);
        aktElem.Add(actionNeu[randEgg]);
        actionNeu.Remove(actionNeu[randEgg]);

        Debug.Log("COUNTERStart " + counter);
        if (counter == 1) { 
            if (randSpeicher % 2 == 0) {
                randHindernis = 1;
            }
            if (randSpeicher % 2 == 1)
            {
                randHindernis = 0;
            }
        }

        aktElem.Add(hindernisNeu[randHindernis]);
        hindernisNeu.Remove(hindernisNeu[randHindernis]);


        aktElem.Add(heuKurzNeu[randHeuKurz]);
        heuKurzNeu.Remove(heuKurzNeu[randHeuKurz]);
        
        


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
        
    }

    // Update is called once per frame
    void Update()
    {

       

        
    }
}

