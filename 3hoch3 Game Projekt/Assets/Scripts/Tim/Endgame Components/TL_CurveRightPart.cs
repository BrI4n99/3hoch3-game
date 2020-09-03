using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_CurveRightPart : MonoBehaviour
{
    [Header("Materials")]
    public Material material1;
    public Material material2;
    public Material material3;

    Material[] mat = new Material[3];

    Vector3[] vertices = new Vector3[32];
    Vector2[] uvs = new Vector2[32];
    Renderer rend;
    Mesh mesh;
    int[][] triangles = new int[3][];

    //Mesh Collider
    MeshCollider meshCollider;

    void Start()
    {
        mesh = new Mesh();
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        mesh.Clear();

        gameObject.AddComponent<MeshRenderer>();
        rend = gameObject.GetComponent<MeshRenderer>();

        mat[0] = material1;
        mat[1] = material2;
        mat[2] = material3;

        rend.materials = mat;

        //------------- Vertices
        //Boden
        vertices[0] = new Vector3(-2.5f, 0, 0);
        vertices[1] = new Vector3(2.5f, 0, 0);
        vertices[2] = new Vector3(-2.5f, 0, 7);
        vertices[3] = new Vector3(2.5f, 0, 7);
        vertices[4] = new Vector3(2.5f, 0, 2);
        vertices[5] = new Vector3(4.5f, 0, 2);
        vertices[6] = new Vector3(2.5f, 0, 7);
        vertices[7] = new Vector3(4.5f, 0, 7);

        //Wand außen links
        vertices[8] = new Vector3(-2.5f, 0, 0);
        vertices[9] = new Vector3(-2.5f, 0, 7);
        vertices[10] = new Vector3(-2.5f, 5, 0);
        vertices[11] = new Vector3(-2.5f, 5, 7);
        //Wand außen hinten
        vertices[12] = new Vector3(-2.5f, 0, 7);
        vertices[13] = new Vector3(4.5f, 0, 7);
        vertices[14] = new Vector3(-2.5f, 5, 7);
        vertices[15] = new Vector3(4.5f, 5, 7);

        //Wand innen rechts
        vertices[16] = new Vector3(2.5f, 0, 0);
        vertices[17] = new Vector3(2.5f, 0, 2);
        vertices[18] = new Vector3(2.5f, 5, 0);
        vertices[19] = new Vector3(2.5f, 5, 2);
        //Wand innen hinten
        vertices[20] = new Vector3(2.5f, 0, 2);
        vertices[21] = new Vector3(4.5f, 0, 2);
        vertices[22] = new Vector3(2.5f, 5, 2);
        vertices[23] = new Vector3(4.5f, 5, 2);
        
        //Decke
        vertices[24] = new Vector3(-2.5f, 5, 0);
        vertices[25] = new Vector3(2.5f, 5, 0);
        vertices[26] = new Vector3(-2.5f, 5, 7);
        vertices[27] = new Vector3(2.5f, 5, 7);
        vertices[28] = new Vector3(2.5f, 5, 2);
        vertices[29] = new Vector3(4.5f, 5, 2);
        vertices[30] = new Vector3(2.5f, 5, 7);
        vertices[31] = new Vector3(4.5f, 5, 7);
        //-------------

        //------------- UVS
        //Boden
        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(1f, 0f);
        uvs[2] = new Vector2(0f, 1f);
        uvs[3] = new Vector2(1f, 1f);
        uvs[4] = new Vector2(0f, 0f);
        uvs[5] = new Vector2(1f, 0f);
        uvs[6] = new Vector2(0f, 1f);
        uvs[7] = new Vector2(1f, 1f);
        //Wand außen links
        uvs[8] = new Vector2(0f, 0f);
        uvs[9] = new Vector2(1f, 0f);
        uvs[10] = new Vector2(0f, 1f);
        uvs[11] = new Vector2(1f, 1f);
        //Wand außen hinten
        uvs[12] = new Vector2(0f, 0f);
        uvs[13] = new Vector2(1f, 0f);
        uvs[14] = new Vector2(0f, 1f);
        uvs[15] = new Vector2(1f, 1f);
        //Wand innen rechts
        uvs[16] = new Vector2(0.4f, 0f);
        uvs[17] = new Vector2(0f, 0f);
        uvs[18] = new Vector2(0.4f, 1f);
        uvs[19] = new Vector2(0f, 1f);
        //Wand innen hinten
        uvs[20] = new Vector2(1f, 0f);
        uvs[21] = new Vector2(1.4f, 0f);
        uvs[22] = new Vector2(1f, 1f);
        uvs[23] = new Vector2(1.4f, 1f);

        //Decke
        uvs[24] = new Vector2(1f, 0f);
        uvs[25] = new Vector2(0f, 0f);
        uvs[26] = new Vector2(0f, 1f);
        uvs[27] = new Vector2(1f, 1f);
        uvs[28] = new Vector2(1f, 0f);
        uvs[29] = new Vector2(0f, 0f);
        uvs[30] = new Vector2(1f, 0f);
        uvs[31] = new Vector2(1f, 1f);
        //-------------

        //------------- Triangles

        triangles[0] = new int[] {
            //Boden
            0,2,1,
            1,2,3,
            4,6,5,
            5,6,7
        };

        triangles[1] = new int[] {
            //Wand außen links
            8,10,11,
            8,11,9,
            //Wand außen hinten
            12,14,15,
            12,15,13,
            //Wand innen rechts
            16,17,19,
            16,19,18,
            //Wand innen hinten
            20,21,23,
            20,23,22
        };

        triangles[2] = new int[] {
            //Decke
            24,25,26,
            25,27,26,
            28,29,30,
            29,31,30
        };
        //-------------

        mesh.subMeshCount = 3;

        mesh.vertices = vertices;
        mesh.uv = uvs;

        mesh.SetTriangles(triangles[0], 0);
        mesh.SetTriangles(triangles[1], 1);
        mesh.SetTriangles(triangles[2], 2);

        mesh.RecalculateNormals();

        //Mesh Collider
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
}
