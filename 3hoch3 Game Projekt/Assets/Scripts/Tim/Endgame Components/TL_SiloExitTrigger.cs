using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TL_SiloExitTrigger : MonoBehaviour
{
    //In Gewinner Szene wechseln
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("ib_Win");
        }
    }
}
