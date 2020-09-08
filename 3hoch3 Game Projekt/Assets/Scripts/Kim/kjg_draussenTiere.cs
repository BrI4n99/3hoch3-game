using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_draussenTiere : MonoBehaviour
{
    public GameObject kuh;
    // Start is called before the first frame update
    void Start()
    {
        if (kjg_kuh.hasKuh) {
            Instantiate(kuh, new Vector3(-2.5f,0,17), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
