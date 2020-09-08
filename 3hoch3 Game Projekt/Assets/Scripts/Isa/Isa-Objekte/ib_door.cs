using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_door : MonoBehaviour
{
    public GameObject door;
    public AudioSource doorSound;
    public int rand;
    bool touch; 
    
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(1, 3);
        rand = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && !touch)
        {
            touch = true;

            if (rand == 1) {
                door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, 165, 0), 40*  Time.deltaTime) ;
                //door.transform.Rotate(new Vector3 (0, 135, 0) * Time.deltaTime );
                Debug.Log("Open Door");
            }
            if (rand == 2)
            {
                //door.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime );
                door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, -45, 0), 7 *Time.deltaTime);
                Debug.Log("close Door");
            }

            doorSound = GetComponent<AudioSource>();
            doorSound.Play();
        }
    }
}
