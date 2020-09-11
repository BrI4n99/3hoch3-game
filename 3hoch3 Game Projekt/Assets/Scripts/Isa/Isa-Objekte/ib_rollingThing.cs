using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ib_rollingThing : MonoBehaviour
{

   IB_Star stars;

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


    /// ////////////////////////////////////////

    public Canvas canvas;
    private static Image star;
    private bool zoom;
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f);

    //////////////////



    // Start is called before the first frame update
    void Start()
    {
        stars = IB_Star.Instance;


        first = true;
        //puffSound = puff.clip;

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
        //stars.StartCoroutine(stars.starZoom());

        //ib_star obj = Camera.main.GetComponent<ib_star>();
        //Coroutine example = StartCoroutine(Camera.main.GetComponent<ib_star>().starZoom());
        yield return new WaitForSeconds(2f);
       
        Destroy(eines.gameObject, 2.5f);

    }
    /*
    public static IEnumerator starZoom()
    {
        Debug.Log("wieder kleiner machen");

        
          Vector3 newScale = star.transform.localScale;
          newScale *= 1.01f;
          star.transform.localScale = newScale;
          yield return new WaitForSeconds(0.1f);

          Debug.Log("wieder sdsajdsad machen");
          newScale = star.transform.localScale;
          newScale *= 1.01f;
          star.transform.localScale = newScale;
          yield return new WaitForSeconds(0.1f);






          Vector3 newScale = star.transform.localScale;
          newScale *= 1.05f;
          star.transform.localScale = newScale;
          yield return new WaitForSeconds(0.05f);



          newScale = star.transform.localScale;
          newScale *= 0.95f;
          star.transform.localScale = newScale;
          yield return new WaitForSeconds(0.05f);


          newScale = star.transform.localScale;
          newScale *= 1.05f;
          star.transform.localScale = newScale;
          yield return new WaitForSeconds(0.05f);


          newScale = star.transform.localScale;
          newScale *= 0.95f;
          star.transform.localScale = newScale;
          yield return new WaitForSeconds(0.05f);

      

}*/


}
