using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_StartPart : MonoBehaviour
{
    [Header("Materials")]
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;

    Material[] mat = new Material[5];

    Vector3[] vertices = new Vector3[56];
    Vector2[] uvs = new Vector2[56];
    Renderer rend;
    Mesh mesh;
    int[][] triangles = new int[5][];

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
        mat[3] = material4;
        mat[4] = material5;

        rend.materials = mat;

        //------------- Vertices
        //Boden oben
        vertices[0] = new Vector3(-2.5f, 0, 0);
        vertices[1] = new Vector3(2.5f, 0, 0);
        vertices[2] = new Vector3(-2.5f, 0, 15);
        vertices[3] = new Vector3(2.5f, 0, 15);

        //Wand oben rechts
        vertices[4] = new Vector3(2.5f, 0, 0);
        vertices[5] = new Vector3(2.5f, 0, 20);
        vertices[6] = new Vector3(2.5f, 5, 0);
        vertices[7] = new Vector3(2.5f, 5, 20);

        //Wand oben links
        vertices[8] = new Vector3(-2.5f, 0, 0);
        vertices[9] = new Vector3(-2.5f, 0, 20);
        vertices[10] = new Vector3(-2.5f, 5, 0);
        vertices[11] = new Vector3(-2.5f, 5, 20);

        //Decke
        vertices[12] = new Vector3(-2.5f, 5, 0);
        vertices[13] = new Vector3(-2.5f, 5, 20);
        vertices[14] = new Vector3(2.5f, 5, 0);
        vertices[15] = new Vector3(2.5f, 5, 20);

        //Wand oben vorne
        vertices[16] = new Vector3(-2.5f, 0, 0);
        vertices[17] = new Vector3(2.5f, 0, 0);
        vertices[18] = new Vector3(-2.5f, 5, 0);
        vertices[19] = new Vector3(2.5f, 5, 0);

        //Wand oben hinten
        vertices[20] = new Vector3(-2.5f, 0, 20);
        vertices[21] = new Vector3(2.5f, 0, 20);
        vertices[22] = new Vector3(-2.5f, 5, 20);
        vertices[23] = new Vector3(2.5f, 5, 20);

        //Wand unten vorne
        vertices[24] = new Vector3(-2.5f, -10, 15);
        vertices[25] = new Vector3(2.5f, -10, 15);
        vertices[26] = new Vector3(-2.5f, 0, 15);
        vertices[27] = new Vector3(2.5f, 0, 15);

        //Wand unten rechts
        vertices[28] = new Vector3(2.5f, -10, 15);
        vertices[29] = new Vector3(2.5f, -10, 20);
        vertices[30] = new Vector3(2.5f, 0, 15);
        vertices[31] = new Vector3(2.5f, 0, 20);

        //Wand unten links
        vertices[32] = new Vector3(-2.5f, -10, 15);
        vertices[33] = new Vector3(-2.5f, -10, 20);
        vertices[34] = new Vector3(-2.5f, 0, 15);
        vertices[35] = new Vector3(-2.5f, 0, 20);

        //Wand unten hinten
        vertices[36] = new Vector3(-2.5f, -5, 20);
        vertices[37] = new Vector3(2.5f, -5, 20);
        vertices[38] = new Vector3(-2.5f, 0, 20);
        vertices[39] = new Vector3(2.5f, 0, 20);

        //Wand unten Gang rechts
        vertices[40] = new Vector3(2.5f, -10, 20);
        vertices[41] = new Vector3(2.5f, -10, 23);
        vertices[42] = new Vector3(2.5f, -5, 20);
        vertices[43] = new Vector3(2.5f, -5, 23);

        //Wand unten Gang links
        vertices[44] = new Vector3(-2.5f, -10, 20);
        vertices[45] = new Vector3(-2.5f, -10, 23);
        vertices[46] = new Vector3(-2.5f, -5, 20);
        vertices[47] = new Vector3(-2.5f, -5, 23);

        //Boden unten
        vertices[48] = new Vector3(-2.5f, -10, 20);
        vertices[49] = new Vector3(2.5f, -10, 20);
        vertices[50] = new Vector3(-2.5f, -10, 23);
        vertices[51] = new Vector3(2.5f, -10, 23);

        //Decke unten
        vertices[52] = new Vector3(-2.5f, -5, 20);
        vertices[53] = new Vector3(2.5f, -5, 20);
        vertices[54] = new Vector3(-2.5f, -5, 23);
        vertices[55] = new Vector3(2.5f, -5, 23);
        //-------------

        //------------- UVS
        //Boden oben
        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(1f, 0f);
        uvs[2] = new Vector2(0f, 1f);
        uvs[3] = new Vector2(1f, 1f);

        //Wand rechts
        uvs[4] = new Vector2(0.8f, 0f);
        uvs[5] = new Vector2(0f, 0f);
        uvs[6] = new Vector2(0.8f, 1f);
        uvs[7] = new Vector2(0f, 1f);

        //Wand links
        uvs[8] = new Vector2(0f, 0f);
        uvs[9] = new Vector2(0.8f, 0f);
        uvs[10] = new Vector2(0f, 1f);
        uvs[11] = new Vector2(0.8f, 1f);

        //Decke
        uvs[12] = new Vector2(1f, 0f);
        uvs[13] = new Vector2(0f, 1f);
        uvs[14] = new Vector2(0f, 0f);
        uvs[15] = new Vector2(1f, 1f);

        //Wand oben vorne
        uvs[16] = new Vector2(0.3f, 0f);
        uvs[17] = new Vector2(0f, 0f);
        uvs[18] = new Vector2(0.3f, 1f);
        uvs[19] = new Vector2(0f, 1f);

        //Wand oben hinten
        uvs[20] = new Vector2(0f, 0f);
        uvs[21] = new Vector2(0.3f, 0f);
        uvs[22] = new Vector2(0f, 1f);
        uvs[23] = new Vector2(0.3f, 1f);

        //Wand unten vorne
        uvs[24] = new Vector2(1f, 0f);
        uvs[25] = new Vector2(0f, 0f);
        uvs[26] = new Vector2(1f, 2f);
        uvs[27] = new Vector2(0f, 2f);

        //Wand unten rechts
        uvs[28] = new Vector2(1f, 0f);
        uvs[29] = new Vector2(0f, 0f);
        uvs[30] = new Vector2(1f, 2f);
        uvs[31] = new Vector2(0f, 2f);

        //Wand unten links
        uvs[32] = new Vector2(0f, 0f);
        uvs[33] = new Vector2(1f, 0f);
        uvs[34] = new Vector2(0f, 2f);
        uvs[35] = new Vector2(1f, 2f);

        //Wand unten hinten
        uvs[36] = new Vector2(0f, 0f);
        uvs[37] = new Vector2(1f, 0f);
        uvs[38] = new Vector2(0f, 1f);
        uvs[39] = new Vector2(1f, 1f);

        //Wand unten Gang rechts
        uvs[40] = new Vector2(0.5f, 0f);
        uvs[41] = new Vector2(0f, 0f);
        uvs[42] = new Vector2(0.5f, 1f);
        uvs[43] = new Vector2(0f, 1f);

        //Wand unten Gang links
        uvs[44] = new Vector2(0f, 0f);
        uvs[45] = new Vector2(0.5f, 0f);
        uvs[46] = new Vector2(0f, 1f);
        uvs[47] = new Vector2(0.5f, 1f);

        //Boden unten
        uvs[48] = new Vector2(0f, 0f);
        uvs[49] = new Vector2(1f, 0f);
        uvs[50] = new Vector2(0f, 1f);
        uvs[51] = new Vector2(1f, 1f);

        //Decke unten
        uvs[52] = new Vector2(1f, 0f);
        uvs[53] = new Vector2(0f, 0f);
        uvs[54] = new Vector2(1f, 1f);
        uvs[55] = new Vector2(0f, 1f);
        //-------------

        //------------- Triangles

        triangles[0] = new int[] {
            //Boden oben
            0,2,1,
            1,2,3,
            //Boden unten
            48,50,49,
            49,50,51
        };

        triangles[1] = new int[] {
            //Wand rechts
            4,5,7,
            4,7,6,
            //Wand links
            8,10,11,
            8,11,9,
            //Wand oben vorne
            16,17,18,
            17,19,18,
            //Wand oben hinten
            20,22,21,
            21,22,23
        };

        triangles[2] = new int[] {
            //Decke
            12,14,13,
            14,15,13
        };

        triangles[3] = new int[] {
            //Wand unten vorne
            24,25,26,
            25,27,26,
            //Wand unten rechts
            28,29,30,
            29,31,30,
            //Wand unten links
            32,34,33,
            33,34,35,
            //Wand unten hinten
            36,38,37,
            37,38,39,
            //Wand unten Gang rechts
            40,41,42,
            41,43,42,
            //Wand unten Gang links
            44,46,45,
            45,46,47
        };

        triangles[4] = new int[]
        {
            //Decke unten
            52,53,54,
            54,53,55
        };
        //-------------

        mesh.subMeshCount = 5;

        mesh.vertices = vertices;
        mesh.uv = uvs;

        mesh.SetTriangles(triangles[0], 0);
        mesh.SetTriangles(triangles[1], 1);
        mesh.SetTriangles(triangles[2], 2);
        mesh.SetTriangles(triangles[3], 3);
        mesh.SetTriangles(triangles[4], 4);

        mesh.RecalculateNormals();

        //Mesh Collider
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
}
