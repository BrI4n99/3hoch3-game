using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_carrot : MonoBehaviour
{
    public Vector3 scaleChange;
    // public int collectedCarrots; 
    // public AudioClip impact;
    public AudioSource eatingCarrots; 
    public static int carrots;
    bool carrotEat = false;
  
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.localScale += scaleChange;
        scaleChange = new Vector3(0.038f, 0.038f, 0.038f);

        eatingCarrots = this.GetComponent<AudioSource>();
        // score= GetComponent<ib_GUI>();
    }

    // Update is called once per frame
    void Update()
    {
    
    // Karotte animieren: drehen --------------------------------------------
        float[] values = {-1, 1, 70, 75, 80, 85, 95, 100};
        float randTime = values[Random.Range(2,8)];           // unteschiedliche Geschwindigkeit  
        float orientation = values[Random.Range(0,1)];      // unterschiedliche Drehrichtung
        this.transform.RotateAround(this.transform.position, new Vector3(0, orientation, 0), randTime * Time.deltaTime);
    }


    // Karotte löschen, wennn Schaf diese berührt und Punkte zählen ---------
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "SheepWhite") {
            // Karotte löschen
            Destroy(gameObject, 0.5f );

        
            if (carrotEat != true) {
                eatingCarrots.Play();
                carrotEat = true;
                // Punkte zählen
                carrots++;
                
            Debug.Log("Yummy, Möööööhrchen!");
            }
        }
        
    }


}
