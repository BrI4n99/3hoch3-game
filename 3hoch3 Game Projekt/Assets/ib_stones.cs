using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_stones : MonoBehaviour
{
    private bool floatUp= true;
    private float wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = Random.Range(2.8f, 4.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floatUp)
        {
            StartCoroutine(floatingDown());
            // StartCoroutine(turnAround());
        }
        else
        {
            StartCoroutine(floatingUp());
        }
    }


    IEnumerator floatingUp()
    {
        gameObject.transform.position += Vector3.up * Time.deltaTime *0.75f;
        yield return new WaitForSeconds(wait);
        floatUp = true;
    }

    IEnumerator floatingDown()
    {
       
        gameObject.transform.position -= Vector3.up* Time.deltaTime * 0.75f;
        yield return new WaitForSeconds(wait);
        floatUp = false;
    }
}
