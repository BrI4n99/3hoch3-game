using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_startScript : MonoBehaviour
{
    public GameObject fence; 
    public GameObject trog; 
    public GameObject carrot;
    public GameObject puddle;

    private Vector3 speicher = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        float rand = ib_balesMethPos.posX[Random.Range(0, 3)];
        Vector3[] positions = new Vector3[3] { new Vector3(rand, 0, 110), new Vector3(rand, 0, 130), new Vector3(rand, 0, 150) };

        ib_balesMethPos meth;
 
        meth = ib_balesMethPos.Instance;
        float i = 3.4f; // Anzahl der Hindernisse
        meth.breit(ib_balesMethPos.posX[Random.Range(0, 3)] , ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i-35, false, ib_balesMethPos.createRandBool(), gameObject);  i++;
        meth.einfach(ib_balesMethPos.posX[Random.Range(0, 3)] , ib_balesMethPos.posY[0], ib_balesMethPos.abstand * i-35, true, false, gameObject);  i++;
        

        // Zufällige Reihenfolge

       for (int j = 0; j < positions.Length; j++) {
            
            int randIndex = Random.Range(0,positions.Length);
                
            speicher = positions[randIndex];
            positions[randIndex] = positions[j];
            positions[j] = speicher; 
        }

       // Objekte instanziieren
        GameObject newFence = Instantiate(fence, transform, false); newFence.name = string.Format("newFence");
        newFence.transform.Translate(new Vector3(-46, 0, positions[0].z)); newFence.transform.Rotate(0, 90, 0);
        GameObject newTrog = Instantiate(trog, transform, false); newTrog.name = string.Format("newTrog"); 
        newTrog.transform.Translate(positions[1]); newTrog.transform.Rotate(270, 0, 0);
        GameObject newcarrot = Instantiate(carrot, transform, false); newcarrot.name = string.Format("newcarrot");
        newcarrot.transform.Translate(positions[2]);
        GameObject newcarrot2 = Instantiate(carrot, transform, false); newcarrot2.name = string.Format("newcarrot");
        newcarrot2.transform.Translate(new Vector3(-32, 0, 44));
        Instantiate(puddle, transform);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
