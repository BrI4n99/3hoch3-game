using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_kamera : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.rotation = Quaternion.Euler(22, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation = target.transform.rotation;
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y +1.5f, target.transform.position.z);

    }
}