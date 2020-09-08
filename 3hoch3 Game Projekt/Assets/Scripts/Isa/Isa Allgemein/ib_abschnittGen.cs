using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_abschnittGen : MonoBehaviour
{

    public GameObject ground;
    public GameObject fence;
    public GameObject fence2;

    public float posZ = 0;

    public List<GameObject> heuLang; // 144
    public List<GameObject> heuKurz; // 72
    public List<GameObject> hindernis; // Pyramide und rollende Fässer // 72
    public List<GameObject> action; // Eier, Brunnen // 72


    public static int randHeuLang;
    public static int randHindernis;
    public static int randEgg;
    public static int randHeuKurz;



    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fence2, transform, false);
        Instantiate(fence, transform, false); // relativ zum Elternobjekt
        Instantiate(ground, transform, false);

        List<GameObject> aktElem = new List<GameObject>();

        randHeuLang = Random.Range(0, heuLang.Count);
        randHindernis = Random.Range(0, hindernis.Count);
        randEgg = Random.Range(0, action.Count);
        randHeuKurz = Random.Range(0, heuKurz.Count);



        aktElem.Add(heuLang[randHeuLang]);
            heuLang.Remove(heuLang[randHeuLang]);
        aktElem.Add(action[randEgg]);
            action.Remove(action[randEgg]);
        aktElem.Add(hindernis[randHindernis]);
            hindernis.Remove(hindernis[randHindernis]);
        aktElem.Add(heuKurz[randHeuKurz]);
            heuKurz.Remove(heuKurz[randHeuKurz]);
        counter++;


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
        for (int i = 0; i < 4; i++) 
        {
            // Debug.Log("VORHER-loc" + localHindernisseArr[i]);
            // Debug.Log("VORHER-anderes" + ib_generator.hindernisseArr[i]);
           //localHindernisseArr[i] = ib_generator.hindernisseArr[i];
            // Debug.Log("nachher" +localHindernisseArr[i]);
            // Debug.Log("nachher" + ib_generator.hindernisseArr[i]);

           // localHeuLangArr[i] = ib_generator.heuLangArr[i];
           // localEggDuckArr[i] = ib_generator.eggDuckArr[i];
        }
    }
}

