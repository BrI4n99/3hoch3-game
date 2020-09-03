using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_carrotFail : MonoBehaviour
{
    int counter;
    public AudioSource eatingCarrots;

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


