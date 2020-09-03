using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_abschnittGen : MonoBehaviour
{

    public GameObject ground;
    public GameObject fence;

    public float posZ = 0;

    public List<GameObject> heuLang; // 144
    public List<GameObject> heuKurz; // 72
    public List<GameObject> hindernis; // Pyramide und rollende Fässer // 72
    public List<GameObject> action; // Eier, Brunnen // 72


    // Start is called before the first frame update
    void Start()
    {

        Instantiate(fence, transform, false); // relativ zum Elternobjekt
        Instantiate(ground, transform, false);

        List<GameObject> aktElem = new List<GameObject>();
        aktElem.Add(heuLang[Random.Range(0, heuLang.Count)]);
        aktElem.Add(action[Random.Range(0, action.Count)]);
        aktElem.Add(hindernis[Random.Range(0, hindernis.Count)]);
        aktElem.Add(heuKurz[Random.Range(0, heuKurz.Count)]);

        
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

