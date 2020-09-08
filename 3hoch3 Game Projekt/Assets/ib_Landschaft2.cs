using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ib_Landschaft2 : MonoBehaviour
{

    [Header("General Settings")]
    [Range(1, 1000)] public int sizeX;
    [Range(1, 1000)] public int sizeY;

    [Header("Point Distribution")]
    [Range(4, 6000)] public int pointDensity;

   // private Polygon polygon;
  //  private TriangleNet.Mesh mesh;
    private UnityEngine.Mesh terrainMesh;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
