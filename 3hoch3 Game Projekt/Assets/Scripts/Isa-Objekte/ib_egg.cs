using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_egg : MonoBehaviour
{

    public static int eggCount = 0;
    public GameObject basketWithEggs;
    bool eggsCheck = false;
    bool hitEgg = false;
    int abzug = 0; 
    AudioSource rollingEgg;
    public AudioSource klingeln; 

    GameObject[] findBasket;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ib_basket")
        {
            // Ei und Korb löschen
            Vector3 posBas = other.transform.position;
            Destroy(gameObject, 0.05f);
            Destroy(other, 0.1f);
            // Anstelle des Korbes Prefab "Korb-mit-Ei" einfügen
            GameObject newBasket = Instantiate(basketWithEggs, posBas, Quaternion.identity);
            klingeln.Play();

            if (eggsCheck != true)
            {
                // Eier hochzählen
                eggCount += 12 - abzug;
                Debug.Log("Du hast " + eggCount + " Eier gesammelt");
                eggsCheck = true;
            }
        }
    }



    void OnCollisionEnter(Collision otherObj)
    {

       // if (hitEgg != true){
            if (otherObj.gameObject.tag == "Player")
            {
                Debug.Log("It's a rolling Egg.");
                rollingEgg = GetComponent<AudioSource>();
                rb = GetComponent<Rigidbody>();
                if (rb.velocity.magnitude >= 1)
                {
                    rollingEgg.Play();
                }
                hitEgg = true;
                Invoke("abziehen", 15F);                  
            }


       // }
    }

    void abziehen() {
        abzug = 6;
    }
}


