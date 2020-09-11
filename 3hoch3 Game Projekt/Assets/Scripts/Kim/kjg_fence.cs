using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_fence : MonoBehaviour
{
    public GameObject fence;
    int fenceLength = 2;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i <= 20; i++) {
            Instantiate(fence, new Vector3(-6, 0, 30), Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
