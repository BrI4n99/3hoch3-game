using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ib_sheepAround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float[] values = { -1, 1, 70, 75, 80, 85, 95, 100 };
        float randTime = values[Random.Range(2, 8)];           // unteschiedliche Geschwindigkeit  
        float orientation = values[Random.Range(0, 1)];      // unterschiedliche Drehrichtung
        this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 50 * Time.deltaTime);
    }
}
