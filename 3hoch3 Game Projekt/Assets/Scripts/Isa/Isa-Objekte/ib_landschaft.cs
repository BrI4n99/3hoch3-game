using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ib_landschaft : MonoBehaviour
{
    public Material mat;
    MeshCollider meshCollider;
    Mesh mesh;
   
    Renderer rend;
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;
    Color[] colors;

    public Gradient gradient;
    float minTerrainHeight;
    float maxTerrainHeight; 

    public int xSize = 500; 
    public int zSize = 540; 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        ShowMesh();

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void ShowMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        // mesh.uv = uvs;
        mesh.colors = colors;
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();


        meshCollider.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }

    void CreateShape() 
    {
        vertices = new Vector3[(xSize + 1) * (zSize +1)];

       
        for (int i = 0, z = 0; z <= zSize; z++) 
        {
            for (int x = 0; x <= xSize; x++) {
                float variable1 =1f;
                float variable2 =1f ;

                float y = Mathf.PerlinNoise(x * .028f * variable1, z * .028f * variable2) * 15f;
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrainHeight) maxTerrainHeight = y;
                if (y < minTerrainHeight) minTerrainHeight = y;
                
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                
            }
            vert++;
        }

        // uvs = new Vector2[vertices.Length];
        colors = new Color[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
               // uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }
    }
}
