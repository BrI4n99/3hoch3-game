using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_rollingThing : MonoBehaviour
{

    GameObject[] MyExplosion;      // Array für alle zu löschenden Objekte
    public AudioSource rolling;
    public AudioSource puff;
    public AudioClip puffSound;

    public static int bonus = 0;
    Rigidbody rb;
    Rigidbody rbBarrel;

    public float thrust = 10f;
    public GameObject staub;
    GameObject partikel;

    bool first;
   // bool second; 

    IB_Star starScript;

    
    public Canvas canvas;
    private static Image star;
   

    // Start is called before the first frame update
    void Start()
    {
        starScript = IB_Star.Instance;
        first = true;
       // second = true;
        canvas = GameObject.FindGameObjectWithTag("ib_LevelUI").GetComponent<Canvas>();
        star = canvas.transform.GetChild(0).GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "explosion")
        {
            // Alle Ballen mit Tag "explosion" löschen, die in der Nähe sind --------------------------------
            Collider[] nearObjects = Physics.OverlapSphere(gameObject.transform.position, 50f);
            foreach (Collider eines in nearObjects)
            {
                if (eines.gameObject.tag == "explosion")
                {
                    // Pyramide zum Einsturz bringen
                    Debug.Log("'Puff - die Pyramide ist eingestürzt");
                    rb = eines.GetComponent<Rigidbody>();                            // Eigenschaften der zu löschenden Ballen verändern 
                    rb.isKinematic = false;
                    rb.drag = 0.3f;

                    Vector3 pos = eines.transform.position;
                    Vector3 target = new Vector3(pos.x, pos.y + 3, pos.z);

                    eines.transform.LookAt(target);
                    rb.AddRelativeForce(0, 0, thrust);                               // Kraft hinzufügen
                    rb.AddForce((target - pos) * thrust);
                    rb.AddForce(0, 0, thrust, ForceMode.Impulse);
                    StartCoroutine(waiting(eines.gameObject));

                    Destroy(eines.gameObject, 0.85f);                                       // Zeitverzögert löschen
                }

                if (first)
                {
                                                         // Punkte addieren
                    ib_StaticVar._score += 200;
                    StartCoroutine(zoom());
                    Debug.Log("+ 200 Punkte: 'Yeees, der Weg ist frei.'");
                    first = false;


                }
                
                // Debug.Log("Partikel");                                                      // Partikelsystem 
                partikel = Instantiate(staub, transform.position, Quaternion.identity);     
                AudioSource.PlayClipAtPoint(puffSound, transform.position);                 // Geräusch der einstürzenden Pyramide

                Destroy(this.gameObject);                                                   // rollendes Objekt löschen
                
            }

        }

        // Charakter: Sound für rollendes Fass ---------------------------------------------------------------
        if (otherObj.gameObject.tag == "Player" || otherObj.gameObject.name == "Kopf")
        {
            
            GetComponent<Rigidbody>().AddForce(transform.forward * 20);
            rolling.Play();
        }
    }

    IEnumerator waiting(GameObject eines)
    {
        //partikel.SetActive(false);
        Destroy(partikel);
     
        yield return new WaitForSeconds(2f);
        Destroy(eines.gameObject, 1.5f);

    }

    IEnumerator zoom()
    {
        StartCoroutine(starScript.zoom());
        yield return new WaitForSeconds(0.1f);
        StopCoroutine(starScript.zoom());
    }

}
