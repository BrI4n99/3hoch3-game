using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_kuhDraussen : MonoBehaviour
{
    private bool up;
    private float sec = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }
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
    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            StartCoroutine(jumpUp(sec));
        }
        else
        {
            StartCoroutine(jumpDown(sec));
        }
    }
}
