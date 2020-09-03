using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_button02 : MonoBehaviour
{

    public static bool touch;
    bool first; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       first = ib_button.first; 
    }

    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")  //  && first == true
            {
                touch = true; 
                Debug.Log("second - off");
               
            }
        }
}
