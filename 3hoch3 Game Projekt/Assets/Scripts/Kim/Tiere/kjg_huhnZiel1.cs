using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_huhnZiel1 : MonoBehaviour
{
    public static bool z1Erreicht;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "huhn") {
            z1Erreicht = true;
        }
    }
}
