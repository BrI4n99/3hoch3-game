using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class kjg_draussen_drinnen : MonoBehaviour
{
    public static bool warDraussen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite")
        {
            SceneManager.LoadScene("kjg-szene");
            warDraussen = true;
        }

    }
}
