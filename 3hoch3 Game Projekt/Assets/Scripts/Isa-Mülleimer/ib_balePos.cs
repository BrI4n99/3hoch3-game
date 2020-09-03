using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_balePos : MonoBehaviour
{


    public GameObject bales;
    public float abschnittNr;

   // Tiefe, nach "hinten" --> Plusrichtung

    // Start is called before the first frame update
    void Start()
    {

    int size = 50;
    Vector3[] values = new Vector3[size];
    int i = 0;
    

    float randPosX = ib_balesMethPos.posX[Random.Range(0,ib_balesMethPos.posX.Length-1)];   
    float randPosY = ib_balesMethPos.posY[Random.Range(0,ib_balesMethPos.posY.Length-1)]; 
    float randPosZ = ib_balesMethPos.posZ[Random.Range(0,ib_balesMethPos.posZ.Length-1)]; 

    float standardHeigth = 0f;
    float standardDistance = 24f;   

    // Array mit Koordinaten befüllen, an denen Heuballen positioniert werden soll
    values[i++] = new Vector3(-40f, 0f, 24f);  // 0
    values[i++] = new Vector3(-8f, 0f, 48f);   // 1
    values[i++] = new Vector3(-24f, 0f, 48f);   // 1
    values[i++] = new Vector3(-40f, 0f, 72f);  // 2   
    values[i++] = new Vector3(-8f, 0f, 96);  // 3   
    values[i++] = new Vector3(-24f, 0f, 96);  // 3       
    values[i++] = new Vector3(-40f, 0f, 132); // 4      
    values[i++] = new Vector3(-24f, 0f, 132); // 5
    values[i++] = new Vector3(-8f, 0f, 264f);  // 6
    values[i++] = new Vector3(-24f, 0f, 264f);  // 7
    values[i++] = new Vector3(-24f, 0f, 300); // 8
    values[i++] = new Vector3(-8f, 0f, 6f);  // 9

  
  values[i++] = new Vector3(-24, 0f, 336); // 10
  values[i++] = new Vector3(-40f, 0f, 336); // 11
  values[i++] = new Vector3(-8, 0f, 336); // 12
    // Möhren positionieren
    // 12 vor einem Heuballen  Vector3 carrotDistance = new Vector3(0, 0, -12);

       
    for (int j = 0; j < i; j++) {
      Vector3 pos = new Vector3(values[j].x, values[j].y, values[j].z + abschnittNr*360f);
      GameObject hayBale = Instantiate(bales, pos, gameObject.transform.rotation);  
      hayBale.name = string.Format("hayBale_"+ j);

    }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
