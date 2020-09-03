using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class kjg_keysDown : MonoBehaviour
{

    public GameObject keys;
    IEnumerator keyDown()
    {
        while (keys.transform.position.y >= 1.6f)
        {
            keys.transform.position -= new Vector3(0, 10f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.01f);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite")
        {
            StartCoroutine(keyDown());
        }
    }
}