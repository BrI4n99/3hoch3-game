using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kjg_tuerDraussen : MonoBehaviour
{
    //Szenenwechesl von drinnen nach draußen
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            SceneManager.LoadScene("kjg-draussen");
        }
      
    }
}
