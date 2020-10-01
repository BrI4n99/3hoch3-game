using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_tomatoTrigger : MonoBehaviour
{
    public static bool hitSheep;
    private float zeit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite") {
            hitSheep = true;
            Debug.Log("Schaf getroffen");
            ib_StaticVar._score -= 50;
            
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        zeit += Time.deltaTime;
        if (zeit > 0.01f) {
            hitSheep = false;
        }
    }
}
