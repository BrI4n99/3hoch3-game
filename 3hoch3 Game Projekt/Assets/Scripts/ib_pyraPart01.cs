using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_pyraPart01 : MonoBehaviour
{
    // Heuballen
    public GameObject block;
    // Kugel
    public GameObject rollingThing;
    public AudioSource puff;

    public int miniabschnitt;
    public Vector3 abschnittPos;
    ib_balesMethPos meth;
    Vector3[] values = new Vector3[7];
    public float posPyr = ib_balesMethPos.abstand;
    public float baleHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        meth = ib_balesMethPos.Instance;
        int i = 0;
        values[i++] = new Vector3(-8, 0, posPyr);                // unten rechts
        values[i++] = new Vector3(-40, 0, posPyr);               //unten links  
        values[i++] = new Vector3(-32, baleHeight, posPyr);      //mittig links //E
        values[i++] = new Vector3(-16, baleHeight, posPyr);      //mittig rechts //E
        values[i++] = new Vector3(-24, baleHeight * 2, posPyr);    // oben mittig //E
        values[i++] = new Vector3(-24, 0, posPyr);               // unten mittig // E
        for (int j = 0; j < i; j++)
        {

            GameObject pyraBlock = Instantiate(block, values[j], gameObject.transform.rotation);
            pyraBlock.name = string.Format("pyraBlock" + j);

            if (j > 1)
            {
                pyraBlock.tag = "explosion";
            }

            if (j < 2)
            {
                pyraBlock.tag = "hayBale";
            }
            if (j == 5)
            {

                // Rollendes Fass ---------------------------------------------------------------------- 
                Vector3 abstand = new Vector3(0, 0, -20);         // 20 Abstand zur Pyramide
                Instantiate(rollingThing, abstand + pyraBlock.transform.position, Quaternion.identity);



            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    void OnCollisionEnter(Collision otherObj)
    {

        // Charakter: Sound für rollendes Fass ---------------------------------------------------------------
            if (otherObj.gameObject.tag == "ib_barrel")
            {
                Debug.Log("'puff.'");
                puff = GetComponent<AudioSource>();
                puff.Play();
            }

    } */


}
