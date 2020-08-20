using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_kuh : MonoBehaviour
{
    //Tiere sollen durcheinander hüpfen und sich zum Ausgang drehen
    bool up;

    private void Start()
    {
        up = false;
    }
    //jumping Methoden
    IEnumerator jumpUp(float seconds)
    {
        this.transform.position += new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(seconds);
        up = false;
    }

    IEnumerator jumpDown(float seconds)
    {
        this.transform.position -= new Vector3(0, 1.5f * Time.deltaTime, 0);
        yield return new WaitForSeconds(seconds);
        up = true;
    }

    float sec;
    // Update is called once per frame
    void Update()
    {
        sec = 0.6f;
        //Hovering / Floating
        if (up)
        {
            StartCoroutine(jumpUp(sec));
        }
        else
        {
            StartCoroutine(jumpDown(sec));
        }

        //Drehen
        //this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 90f * Time.deltaTime);
    }
}
