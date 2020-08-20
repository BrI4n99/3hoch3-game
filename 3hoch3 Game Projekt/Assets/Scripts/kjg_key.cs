using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class kjg_key : MonoBehaviour
{
    public GameObject keys;
    public bool hasKey;
    bool floatUp;
   
    private void Start()
    {
        floatUp = false;
    }

    //Schlüssel einsammeln
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            hasKey = true;
             Destroy(this.gameObject);


            Debug.Log("Du hast den Schlüssel gesammelt! " + hasKey);
        }
    }

    //Floating Methoden
    IEnumerator floatingUp() {
        keys.transform.position += new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(0.5f);
        floatUp = false;
    }

    IEnumerator floatingDown()
    {
        keys.transform.position -= new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(0.5f);
        floatUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Hovering / Floating
        if (floatUp)
        {
            StartCoroutine(floatingUp());
        }
        else {
            StartCoroutine(floatingDown());
        }

        //Drehen
        this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 90f * Time.deltaTime);
    }
}
