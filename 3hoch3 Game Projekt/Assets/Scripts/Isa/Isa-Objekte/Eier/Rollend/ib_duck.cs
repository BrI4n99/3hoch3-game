using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_duck : MonoBehaviour
{
    public static int minuspunkte;
    public static int abzug = -100;
    bool touch;
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
                ib_StaticVar._score += abzug;
                // minuspunkte += abzug;
                Debug.Log("Punktabzug: 'Hey, lass das Huhn in Ruhe!'");
                touch = true;

            }

        }
    }

}
