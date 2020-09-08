using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_rollingThing : MonoBehaviour
{
    GameObject[] MyExplosion;      // Array für alle zu löschenden Objekte
    public AudioSource rolling;
    public AudioSource puff;
    public AudioClip puffSound;

    public static int bonus = 0;
    Rigidbody rigidbody;
    Rigidbody rbBarrel;

    public float thrust = 10f;
    public GameObject staub;
    GameObject partikel;

    bool first;

    // Start is called before the first frame update
    void Start()
    {
        first = true;
        //puffSound = puff.clip;
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
                    Debug.Log("'Puff");
                   // puff.Play();
                    rigidbody = eines.GetComponent<Rigidbody>();
                    rigidbody.isKinematic = false;

                    rigidbody.drag = 0.3f;

                    Vector3 pos = eines.transform.position;
                    Vector3 target = new Vector3(pos.x, pos.y + 3, pos.z);

                    eines.transform.LookAt(target);
                    rigidbody.AddRelativeForce(0, 0, thrust);
                    rigidbody.AddForce((target - pos) * thrust);
                    rigidbody.AddForce(0, 0, thrust, ForceMode.Impulse);
                    StartCoroutine(waiting(eines.gameObject));

                    Destroy(eines.gameObject, 0.85f);
                }

                if (first)
                {
                                             // rollendes Objekt löschen

                    bonus += 250;
                    Debug.Log("Bonuspunkte: 'Yeees, der Weg ist frei.'");
                    first = false;
                }
                Debug.Log("Partikel");
                partikel = Instantiate(staub, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(puffSound, transform.position);

                Destroy(this.gameObject);
            }

        }

        // Charakter: Sound für rollendes Fass ---------------------------------------------------------------
        if (otherObj.gameObject.tag == "Player" || otherObj.gameObject.name == "Kopf")
        {
            Debug.Log("'It's a rolling thing.'");
            //rolling = GetComponent<AudioSource>();
            rolling.Play();
        }

    }

    IEnumerator waiting(GameObject eines)
    {
        partikel.SetActive(false);
        Destroy(partikel);
        Debug.Log("WaitingFor10SEC");
        yield return new WaitForSeconds(2f);
        Destroy(eines.gameObject, 2.5f);

    }





}
