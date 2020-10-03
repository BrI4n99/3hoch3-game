using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_mushroom : MonoBehaviour
{
    public GameObject pilz;

   
    public Vector3 scaleChange;
 
    public AudioSource eating;
   
    public static int carrots;
    bool eat = false;
  
    public GameObject sheep;

    Vector3 sheepPos;
    Quaternion sheepRot;
    Vector3 carrotPos;
    Vector3 carrotPos2;
    Quaternion carrotRot;


    // Start is called before the first frame update
    void Start()
    {
       
        //eating = mushroom.GetComponent<AudioClip>();
        sheep = GameObject.FindWithTag("PlayerColl");
        pilz = this.gameObject;
       // eating = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //sheepRot = sheep.transform.rotation;

        
            // Karotte animieren: drehen --------------------------------------------
            float[] values = { -1, 1, 70, 75, 80, 85, 95, 100 };
            float randTime = values[Random.Range(2, 8)];           // unteschiedliche Geschwindigkeit  
            float orientation = values[Random.Range(0, 1)];      // unterschiedliche Drehrichtung
            this.transform.RotateAround(this.transform.position, new Vector3(0, orientation, 0), randTime * Time.deltaTime);
       
        
    }


    // Karotte löschen, wennn Schaf diese berührt und Punkte zählen ---------
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ib_CollCarrots")
        {
            if (!eat)
            {
                eating.Play();
                eat = true;
               
                StartCoroutine(eatMushroom());
              
              

                // Möhren abziehen
                ib_StaticVar._carrots--;
                ib_StaticVar._carrots--;
                Debug.Log("Ohhh, der Pilz war wohl giftig!");
             
            }

        }

    }

    // Möhre fressen: drehen, mitnehmen, nach und nach beißen
    IEnumerator eatMushroom()
    {
        float angle = sheepRot.eulerAngles.y;
        pilz.transform.rotation = Quaternion.Euler(0, 0, 90);
        pilz.transform.Rotate(0, angle, 0, Space.World);
        pilz.transform.SetParent(sheep.transform);
        yield return new WaitForSeconds(0.2f);
        pilz.transform.localPosition = new Vector3(0.02f, 0.622f, 0.52f);
        pilz.transform.localRotation = Quaternion.Euler(0, 4, 90);
        yield return new WaitForSeconds(0.3f);
        pilz.transform.localPosition = new Vector3(0.2f, 0.582f, 0.52f);
        pilz.transform.localRotation = Quaternion.Euler(0, -6, 94);
        yield return new WaitForSeconds(0.4f);
        Destroy(pilz);                                                                // Karotte löschen
    }

}
