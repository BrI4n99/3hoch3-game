using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_kamerafahrt : MonoBehaviour
{
    public GameObject vCam1;
    public GameObject vCam2;

    private float zeit;

    void Start()
    {
        vCam1.SetActive(true);
        vCam2.SetActive(false);
        StartCoroutine(startSound());

    }
    IEnumerator startSound() {
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Play();
    }

        void Update()
    {
        zeit += Time.deltaTime;
        if (zeit > 0.5f) {

            vCam1.SetActive(false);
            vCam2.SetActive(true);
        }
    }
}
