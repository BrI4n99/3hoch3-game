using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_carrot : MonoBehaviour
{
    public GameObject moehre;
    public Vector3 scaleChange;
    // public int collectedCarrots; 
    // public AudioClip impact;
    public AudioSource eatingCarrots; 
    public static int carrots;
    bool carrotEat = false;
    bool touch;
    public GameObject sheep;

    public Vector3 sheepPos;
    public Quaternion sheepRot;
    public Vector3 carrotPos;
    public Vector3 carrotPos2;
    public Quaternion carrotRot;
    float hoehe;
    float zRot;
    Vector3  cInWordSpace;


    // Start is called before the first frame update
    void Start()
    {

       sheep = GameObject.FindWithTag("PlayerColl");
       moehre = this.gameObject;
       hoehe = moehre.transform.position.y;
       eatingCarrots = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //sheepRot = sheep.transform.rotation;

        if (!touch)
        {
            // Karotte animieren: drehen --------------------------------------------
            float[] values = { -1, 1, 70, 75, 80, 85, 95, 100 };
            float randTime = values[Random.Range(2, 8)];           // unteschiedliche Geschwindigkeit  
            float orientation = values[Random.Range(0, 1)];      // unterschiedliche Drehrichtung
            this.transform.RotateAround(this.transform.position, new Vector3(0, orientation, 0), randTime * Time.deltaTime);
        }
        else { 
            StartCoroutine(eatCarrot());
        }
    }


    // Karotte löschen, wennn Schaf diese berührt und Punkte zählen ---------
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ib_CollCarrots") {
            if (!carrotEat)
            {
                eatingCarrots.Play();
                // Punkte zählen
                carrots++;
                Debug.Log("Yummy, Möööööhrchen!");
                carrotEat = true;
                touch = true;
            }       
        }
        
    }

    // Möhre fressen: drehen, mitnehmen, nach und nach beißen
    IEnumerator eatCarrot()
    {
        float angle = sheepRot.eulerAngles.y;
        moehre.transform.rotation = Quaternion.Euler(0, 0, 90);
        moehre.transform.Rotate(0, angle, 0, Space.World) ;
        moehre.transform.SetParent(sheep.transform);
        yield return new WaitForSeconds(0.1f);
        moehre.transform.localPosition =  new Vector3(0.02f, 0.622f, 0.52f);
        moehre.transform.localRotation = Quaternion.Euler(0, 4, 90);
        yield return new WaitForSeconds(0.3f);
        moehre.transform.localPosition = new Vector3(0.2f, 0.582f, 0.52f);
        moehre.transform.localRotation = Quaternion.Euler(0, -6, 94);
        yield return new WaitForSeconds(0.3f);
        Destroy(moehre);                                                                // Karotte löschen
    }

}
