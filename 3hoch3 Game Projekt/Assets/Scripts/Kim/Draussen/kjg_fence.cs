using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class kjg_fence : MonoBehaviour
{
    public GameObject fence;
    private int fenceLength = 2;
    private float fenceHeight = 0f;
    public Material matFence;
 

    void Start()
    {
        for (int i = 0; i <= 10; i++) {
            Instantiate(fence, new Vector3(0-fenceLength*i, fenceHeight, 20), Quaternion.identity);
            Instantiate(fence, new Vector3(0 - fenceLength * i, fenceHeight, 0), Quaternion.identity);
        }
        for (int j = 0; j <= 9; j++) {
            Instantiate(fence, new Vector3(-22f, fenceHeight, fenceLength * j), Quaternion.AngleAxis(90, Vector3.up));
        }
    }

}
