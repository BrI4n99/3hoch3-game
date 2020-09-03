using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_rollingThing : MonoBehaviour
{
    GameObject[] MyExplosion;      // Array für alle zu löschenden Objekte
    public AudioSource rolling;
    // public AudioSource puff;

    public static int bonus = 0;
    public Rigidbody rb;
    Rigidbody rbBarrel;

    public float thrust = 5000000f;

    // Start is called before the first frame update
    void Start()
    {
        rolling.GetComponents<AudioSource>();
        // puff.GetComponents<AudioSource>();

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
                    rb = eines.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.drag = 0.3f;

                    Vector3 pos = eines.transform.position;
                    Vector3 target = new Vector3(pos.x, pos.y + 15, pos.z);

                    eines.transform.LookAt(target);
                    rb.AddRelativeForce(0, 0, thrust);
                    rb.AddForce((target - pos) * thrust);
                    rb.AddForce(0, 0, thrust, ForceMode.Impulse);
                    Destroy(eines.gameObject, 0.8f);              // Heuballen mit Tag löschen
                }
            }
            Destroy(this.gameObject);                           // rollendes Objekt löschen
            bonus = 250;
            Debug.Log("Bonuspunkte: 'Yeees, der Weg ist frei.'");
        }

        // Charakter: Sound für rollendes Fass ---------------------------------------------------------------
        if (otherObj.gameObject.tag == "Player")
        {
            Debug.Log("'It's a rolling thing.'");
            rolling.Play();
        }

        // Fass löschen
        if (otherObj.gameObject.tag == "hayBale")
        {
            Destroy(this.gameObject);
        }
    }

}
