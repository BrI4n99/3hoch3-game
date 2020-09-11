using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_draussenTiere : MonoBehaviour
{
    public GameObject kuh;
    public GameObject sheep;
    void Start()
    {
        //Kuh mit nach draussen nehmen
        if (kjg_kuh.hasKuh) {
            Instantiate(kuh, new Vector3(sheep.transform.position.x-2, sheep.transform.position.y, sheep.transform.position.z +2), Quaternion.identity);
        }
    }
}
