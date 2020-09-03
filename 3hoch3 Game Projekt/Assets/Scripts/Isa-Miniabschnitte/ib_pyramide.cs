using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_pyramide : MonoBehaviour
{
    public GameObject block;

        // Kugel
    public GameObject rollingThing;
    public Material heu2;
    public AudioSource puff; 
    public float posPyr = 190f;
    public float baleHeight = 3f; 
    public Vector3 abstand = new Vector3(0, 0, 0);   

    // Start is called before the first frame update
    void Start()
    {


    int size = 50;
    Vector3[] values = new Vector3[size];
    int i = 0;

    

    // Array mit Koordinaten befüllen, an denen Heuballen positioniert werden soll
    values[i++] = new Vector3(-8, 0, posPyr);                // unten rechts
    values[i++] = new Vector3(-40, 0, posPyr);               //unten links  
    values[i++] = new Vector3(-32, baleHeight, posPyr);      //mittig links //E
    values[i++] = new Vector3(-16, baleHeight, posPyr);      //mittig rechts //E
    values[i++] = new Vector3(-24, baleHeight*2, posPyr);    // oben mittig //E
    values[i++] = new Vector3(-24, 0, posPyr);              // unten mittig // E
       
    for (int j = 0; j < i; j++) {

      GameObject pyraBlock = Instantiate(block, transform, false);  
      pyraBlock.name = string.Format("pyraBlock"+ j);
      pyraBlock.transform.Translate(values[j]);
      pyraBlock.transform.position += new Vector3(8, 0, 0);


      if (j > 1) {
        pyraBlock.tag = "explosion";
      }

      if (j < 2) {
        pyraBlock.tag = "hayBale";
      }
      if ( j == 5) {

        // -------------------------------------------------------
        // Rollender Gegenstand 
       GameObject poisonBarr = Instantiate(rollingThing, transform, false);
        poisonBarr.transform.Translate(abstand);

      }

    }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnCollisionEnter(Collision otherObj)
    {
            if (otherObj.gameObject.tag == "ib_barrel")
            {
                Debug.Log("'puff.'");
                puff = GetComponent<AudioSource>();
                puff.Play();
            }

    } 




    
}
