using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_splat : MonoBehaviour
{

    public AudioSource water;
    private bool touch;
    private int abzug = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.tag == "Player")                                // Kollision mit dem Zaun gibt einmal Punktabzug
        {
            if (touch != true)
            {
                ib_StaticVar._score -= abzug;
                Debug.Log("Punktabzug: Nicht in die Pfützen springen!'");
                touch = true;
                water = GetComponent<AudioSource>();
                water.Play();

            }

        }
    }
}
