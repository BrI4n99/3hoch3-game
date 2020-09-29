using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_decorationFence : MonoBehaviour
{

    public List<GameObject> elements;
    List<GameObject> aktElem = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        Vector3 pos = gameObject.transform.position;      

        float len = GetComponent<ib_abstandNR>().laenge;

        for (int i = 2; i < len*5; ) {
            int rand = Random.Range(0, 8);
            if (rand < 6)
            {
                GameObject newObj = Instantiate(elements[rand], pos + new Vector3(-0.5f, -0.5f, i), Quaternion.identity);

                if (rand <= 2) newObj.transform.rotation = Quaternion.Euler(270, 0, 0);
                newObj.transform.parent = gameObject.transform;
               
            }
            else
            {
                GameObject newObj = Instantiate(elements[rand], transform, false);
                newObj.transform.position = pos + new Vector3(-0.5f, 1.5f, i);
                newObj.transform.rotation = Quaternion.Euler(270, 0, 0);
                // newObj.transform.parent = gameObject.transform;
            }
           
            
            i = i + Random.Range(8, 24);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
