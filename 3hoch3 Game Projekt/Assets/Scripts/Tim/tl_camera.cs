using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tl_camera : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(22, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, 2.3f, target.transform.position.z - 3.3f);
    }
}
