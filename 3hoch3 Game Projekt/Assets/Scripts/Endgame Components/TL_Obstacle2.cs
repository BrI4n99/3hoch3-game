using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_Obstacle2 : MonoBehaviour
{
    [Header("Materials")]
    public Material material1;
    public Material material2;
    public Material material3;

    Material[] mat = new Material[3];

    Vector3[] vertices = new Vector3[64];
    Vector2[] uvs = new Vector2[64];
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
        vertices[2] = new Vector3(-2.5f, 0, 9);
        vertices[3] = new Vector3(2.5f, 0, 9);

        vertices[4] = new Vector3(2.5f, 0, 4);
        vertices[5] = new Vector3(25f, 2, 4);
        vertices[6] = new Vector3(2.5f, 0, 9);
        vertices[7] = new Vector3(25f, 2, 9);

        vertices[8] = new Vector3(25f, 2, 14);
        vertices[9] = new Vector3(25f, 2, 4);
        vertices[10] = new Vector3(30f, 2, 14);
        vertices[11] = new Vector3(30f, 2, 4);

        //Wand außen 1
        vertices[12] = new Vector3(-2.5f, 0, 0);
        vertices[13] = new Vector3(-2.5f, 0, 9);
        vertices[14] = new Vector3(-2.5f, 5, 0);
        vertices[15] = new Vector3(-2.5f, 5, 9);

        //Wand außen 2
        vertices[16] = new Vector3(-2.5f, 0, 9);
        vertices[17] = new Vector3(2.5f, 0, 9);
        vertices[18] = new Vector3(-2.5f, 5, 9);
        vertices[19] = new Vector3(2.5f, 5, 9);

        //Wand außen 3
        vertices[20] = new Vector3(2.5f, 0, 9);
        vertices[21] = new Vector3(25f, 0, 9);
        vertices[22] = new Vector3(2.5f, 10, 9);
        vertices[23] = new Vector3(25f, 10, 9);

        //Wand außen 4
        vertices[24] = new Vector3(25f, 2, 9);
        vertices[25] = new Vector3(25f, 2, 14);
        vertices[26] = new Vector3(25f, 7, 9);
        vertices[27] = new Vector3(25f, 7, 14);

        //Wand innen 1
        vertices[28] = new Vector3(2.5f, 0, 4);
        vertices[29] = new Vector3(2.5f, 0, 0);
        vertices[30] = new Vector3(2.5f, 5, 4);
        vertices[31] = new Vector3(2.5f, 5, 0);

        //Wand innen 2
        vertices[32] = new Vector3(25f, 0, 4);
        vertices[33] = new Vector3(2.5f, 0, 4);
        vertices[34] = new Vector3(25f, 10, 4);
        vertices[35] = new Vector3(2.5f, 10, 4);

        //Wand innen 3
        vertices[36] = new Vector3(30f, 2, 4);
        vertices[37] = new Vector3(25f, 2, 4);
        vertices[38] = new Vector3(30f, 7, 4);
        vertices[39] = new Vector3(25f, 7, 4);

        //Wand innen 4
        vertices[40] = new Vector3(30f, 2, 14);
        vertices[41] = new Vector3(30f, 2, 4);
        vertices[42] = new Vector3(30f, 7, 14);
        vertices[43] = new Vector3(30f, 7, 4);

        //Decke
        vertices[44] = new Vector3(-2.5f, 5, 0);
        vertices[45] = new Vector3(2.5f, 5, 0);
        vertices[46] = new Vector3(-2.5f, 5, 9);
        vertices[47] = new Vector3(2.5f, 5, 9);

        vertices[48] = new Vector3(2.5f, 5, 4);
        vertices[49] = new Vector3(21f, 6.7f, 4);
        vertices[50] = new Vector3(2.5f, 5, 9);
        vertices[51] = new Vector3(21f, 6.7f, 9);

        vertices[52] = new Vector3(30f, 7, 4);
        vertices[53] = new Vector3(30f, 7, 14);
        vertices[54] = new Vector3(25f, 7, 4);
        vertices[55] = new Vector3(25f, 7, 14);

        //Deckenwand 1
        vertices[56] = new Vector3(21f, 6.7f, 4);
        vertices[57] = new Vector3(21f, 6.7f, 9);
        vertices[58] = new Vector3(21f, 10, 4);
        vertices[59] = new Vector3(21f, 10, 9);

        //Deckenwand 2
        vertices[60] = new Vector3(25f, 7, 9);
        vertices[61] = new Vector3(25f, 7, 4);
        vertices[62] = new Vector3(25f, 10, 9);
        vertices[63] = new Vector3(25f, 10, 4);
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

        uvs[8] = new Vector2(0f, 0f);
        uvs[9] = new Vector2(1f, 0f);
        uvs[10] = new Vector2(0f, 1f);
        uvs[11] = new Vector2(1f, 1f);

        //Wand außen 1
        uvs[12] = new Vector2(0f, 0f);
        uvs[13] = new Vector2(2f, 0f);
        uvs[14] = new Vector2(0f, 1f);
        uvs[15] = new Vector2(2f, 1f);

        //Wand außen 2
        uvs[16] = new Vector2(0f, 0f);
        uvs[17] = new Vector2(1f, 0f);
        uvs[18] = new Vector2(0f, 1f);
        uvs[19] = new Vector2(1f, 1f);

        //Wand außen 3
        uvs[20] = new Vector2(0f, 0f);
        uvs[21] = new Vector2(3f, 0f);
        uvs[22] = new Vector2(0f, 2f);
        uvs[23] = new Vector2(3f, 2f);

        //Wand außen 4
        uvs[24] = new Vector2(0f, 0f);
        uvs[25] = new Vector2(1f, 0f);
        uvs[26] = new Vector2(0f, 1f);
        uvs[27] = new Vector2(1f, 1f);

        //Wand innen 1
        uvs[28] = new Vector2(0f, 0f);
        uvs[29] = new Vector2(1f, 0f);
        uvs[30] = new Vector2(0f, 1f);
        uvs[31] = new Vector2(1f, 1f);

        //Wand innen 2
        uvs[32] = new Vector2(0f, 0f);
        uvs[33] = new Vector2(3f, 0f);
        uvs[34] = new Vector2(0f, 2f);
        uvs[35] = new Vector2(3f, 2f);

        //Wand innen 3
        uvs[36] = new Vector2(0f, 0f);
        uvs[37] = new Vector2(1f, 0f);
        uvs[38] = new Vector2(0f, 1f);
        uvs[39] = new Vector2(1f, 1f);

        //Wand innen 4
        uvs[40] = new Vector2(0f, 0f);
        uvs[41] = new Vector2(2f, 0f);
        uvs[42] = new Vector2(0f, 1f);
        uvs[43] = new Vector2(2f, 1f);

        //Decke
        uvs[44] = new Vector2(1f, 0f);
        uvs[45] = new Vector2(0f, 0f);
        uvs[46] = new Vector2(1f, 1f);
        uvs[47] = new Vector2(0f, 1f);

        uvs[48] = new Vector2(1f, 0f);
        uvs[49] = new Vector2(0f, 0f);
        uvs[50] = new Vector2(1f, 1f);
        uvs[51] = new Vector2(0f, 1f);

        uvs[52] = new Vector2(1f, 0f);
        uvs[53] = new Vector2(0f, 0f);
        uvs[54] = new Vector2(1f, 1f);
        uvs[55] = new Vector2(0f, 1f);

        //Deckenwand 1
        uvs[56] = new Vector2(0f, 0f);
        uvs[57] = new Vector2(1f, 0f);
        uvs[58] = new Vector2(0f, 1f);
        uvs[59] = new Vector2(1f, 1f);

        //Deckenwand 2
        uvs[60] = new Vector2(0f, 0f);
        uvs[61] = new Vector2(1f, 0f);
        uvs[62] = new Vector2(0f, 1f);
        uvs[63] = new Vector2(1f, 1f);
        //-------------

        //------------- Triangles

        triangles[0] = new int[] {
            //Boden
            0,2,1,
            1,2,3,
            4,6,5,
            5,6,7,
            8,11,9,
            8,10,11
        };

        triangles[1] = new int[] {
            //Wand außen 1
            12,14,13,
            13,14,15,
            //Wand außen 2
            16,18,17,
            17,18,19,
            //Wand außen 3
            20,22,21,
            21,22,23,
            //Wand außen 4
            25,24,26,
            25,26,27,
            //Wand innen 1
            28,30,31,
            28,31,29,
            //Wand innen 3
            32,35,33,
            32,34,35,
            //Wand innen 3
            36,39,37,
            36,38,39,
            //Wand innen 4
            40,42,43,
            40,43,41,
            //Deckenwand 1
            56,58,57,
            57,58,59,
            //Deckenwand 2
            60,63,61,
            60,62,63
        };

        triangles[2] = new int[] {
            //Decke
            44,45,46,
            45,47,46,
            48,49,50,
            49,51,50,
            54,52,55,
            52,53,55,
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
