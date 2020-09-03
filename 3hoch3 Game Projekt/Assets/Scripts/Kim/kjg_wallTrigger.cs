using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_wallTrigger : MonoBehaviour
{

    public static bool trigger;
    public static int a, b;

    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            trigger = true;
            Debug.Log("Oh nein, noch eine Wand");
        }
        a = Random.Range(0,5);
        Debug.Log("a= " + a);
        b = Random.Range(0,5);
        Debug.Log("b= " + b);

    }
}
