using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_carrotFail : MonoBehaviour
{
    int counter;
    

    // Start is called before the first frame update
    void Start()
    {
        counter = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 3) {
            Destroy(gameObject);
        }

        // Karotte animieren: drehen --------------------------------------------
        float[] values = { -1, 1, 70, 75, 80, 85, 95, 100 };
        float randTime = values[Random.Range(2, 8)];           // unteschiedliche Geschwindigkeit  
        float orientation = values[Random.Range(0, 1)];      // unterschiedliche Drehrichtung
        this.transform.RotateAround(this.transform.position, new Vector3(0, orientation, 0), randTime * Time.deltaTime);
    }

void OnTriggerEnter(Collider other) {
    
        if (other.gameObject.name == "SheepWhite" && counter < 3) {
            // Karotte bewegen
         transform.Translate(new Vector3(0, 2.5f, 15)*  Time.deltaTime * 50); 
         counter++; 
            
        }
        
    }

    IEnumerator floatingUp(GameObject O) {
        O.transform.position += new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(0.5f);
    }

}


