using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_trog : MonoBehaviour
{
    public int abzug = -25;
    public AudioSource sheep;
    private bool touch = false;
    public static int minuspunkte = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            if (touch != true)
            {
                minuspunkte += abzug;
                Debug.Log("Punktabzug: 'Autsch, das war ein Heuballen!'");
                touch = true;
                sheep = GetComponent<AudioSource>();
                sheep.Play();

            }

        }
    }

}
